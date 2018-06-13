using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{

	private Transform playerTransform;
	private float spawnZ = -10.0f;
	private float tileLength = 10.0f;
	private int tilesOnScreen = 7;
	private float safeZone = 15;
	private int lastPrefabIndex = 0; 

	private List<GameObject> activeTiles; 
	
	public GameObject[] tilePrefabs;
	
	void Start ()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		
		activeTiles = new List<GameObject>();
		for (int i = 0; i < tilesOnScreen; i++)
		{
			if (i < 2)
			{
				SpawnTile(0);
			}
			else
			{
				SpawnTile();
			}
			
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (playerTransform.position.z - safeZone > spawnZ - tilesOnScreen * tileLength)
		{
			SpawnTile();
			DeleteTile();
		}
	}

	private void SpawnTile(int prefabIndex = -1)
	{
		GameObject newTile;
		if (prefabIndex == -1)
		{
			newTile = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
		}
		else
		{
			newTile = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
		}
		newTile.transform.SetParent(transform);
		newTile.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		activeTiles.Add(newTile); 
	}

	private void DeleteTile()
	{
		Destroy(activeTiles[0]); 
		activeTiles.RemoveAt(0);
	}

	private int RandomPrefabIndex()
	{
		if (tilePrefabs.Length <= 1)
		{
			return 0; 
		}
	
		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex)
		{
			randomIndex = Random.Range(0, tilePrefabs.Length); 
		}

		lastPrefabIndex = randomIndex; 
		return randomIndex;
	}
}
