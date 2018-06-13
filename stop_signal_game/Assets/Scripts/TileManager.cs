using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

	private Transform playerTransform;
	private float spawnZ = 0.0f;
	private float tileLength = 10.0f;
	private int tilesOnScreen = 7; 
	
	
	public GameObject[] tilePrefabs;
	
	void Start ()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		for (int i = 0; i < tilesOnScreen; i++)
		{
			SpawnTile();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (playerTransform.position.z > spawnZ - tilesOnScreen * tileLength)
		{
			SpawnTile();
		}
	}

	private void SpawnTile(int prefabIndex = -1)
	{
		GameObject newTile;
		newTile = Instantiate(tilePrefabs[0]) as GameObject;
		newTile.transform.SetParent(transform);
		newTile.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength; 
	}
}
