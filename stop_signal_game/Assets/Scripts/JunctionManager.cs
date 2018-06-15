using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

public class JunctionManager : MonoBehaviour
{
	private List<Junction> allJunctions; //TODO: maybe a different collection data type
	//private Junction currentJunction; //the junction that the player is currently on?
	
	private List<GameObject> activeJunctions; //list of junction game objects that are in the scene

	private float pathWidth = 10; 

	private float crossroadLength = 10;

	private Transform playerTransform;
	private GameObject player; 
	
	public List<GameObject> junctionPrefabs;
	
	//[Range(1.0f, 10.0f)] 
	public float speed = 5.0f; 

	// Use this for initialization
	void Start ()
	{
		//get player info	
		player = GameObject.FindGameObjectWithTag("Player");
		playerTransform = player.transform; 
		activeJunctions = new List<GameObject>();
		
		GameObject path1 = Instantiate(junctionPrefabs[0]) as GameObject;
		path1.transform.SetParent(transform);
		activeJunctions.Add(path1);
		
		
		//allJunctions = GenerateJunctions(20);
		
		//currentJunction = allJunctions[0];
		
		
		//SpawnJunctions(); 
	}
	
	// Update is called once per frame
	void Update () {
		//TODO check if the player has crossed over a certain point and spawn more junctions
		
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			RotateWorld('l');
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			RotateWorld('r'); 
	}
		
		MoveWorld();	
		
	}

	//will generate a list of junctions that will build the level
	//this list must be ~75% go trials and ~25% stop trials
	//junctions also have a length of time before stimulus is shown
//	private List<Junction> GenerateJunctions(int numberOfTrials)
//	{
////		//to do: make this do random stuff etc
////		List<Junction> list  = new List<Junction>();
////		for (int i = 0; i < numberOfTrials; i++)
////		{
////			list.Add(new Junction(true, 'r', 1, 10f));
////		}
////		//Debug.Log(list.Count);
////		return list; 
//	}
	
	//spawn 3 new junctions in each of the 3 direcions, left right and ahead
	//this will happen immediately after a player chooses a direction (or runs out of time) 
	private void SpawnJunctions(Junction currentJunction)
	{
		Debug.Log("Spawn Junctions"); 
		//
//		GameObject leftPath = Instantiate(junctionPrefabs[0]) as GameObject; 
//		leftPath.transform.SetParent(transform);
//		leftPath.transform.Rotate(Vector3.up, -90);
//		leftPath.transform.position = new Vector3(-pathWidth/2, 0, crossroadLength + currentJunction.getPathLength() - pathWidth/2);
//		//activeJunctions.Add(leftPath);
//		
//		GameObject rightPath = Instantiate(junctionPrefabs[0]) as GameObject; 
//		rightPath.transform.SetParent(transform);	
//		rightPath.transform.Rotate(Vector3.up, 90);
//		rightPath.transform.position = new Vector3(pathWidth/2, 0, crossroadLength + currentJunction.getPathLength() - pathWidth/2);
//		//activeJunctions.Add(rightPath);
//		
		GameObject forewardPath = Instantiate(junctionPrefabs[0]) as GameObject; 
		forewardPath.transform.SetParent(transform);
		forewardPath.transform.position = Vector3.forward * (crossroadLength + currentJunction.getPathLength());
		activeJunctions.Add(forewardPath);
		Debug.Log(activeJunctions); 
	}

	private void DestroyJunctions()
	{
		
	}

	private void ChangeCurrentJunction()
	{
		
	}
	
	//moves the world towards the player
	private void MoveWorld()
	{
		transform.position += Vector3.back * speed * Time.deltaTime; 
	}

	//rotates the world around player in a specified direction
	private void RotateWorld(char direction)
	{
		if (direction == 'l' || direction == 'L')
		{
			transform.RotateAround(playerTransform.position, Vector3.up, 300 * Time.deltaTime);
		}
		else if (direction == 'r' || direction == 'R')
		{
			transform.RotateAround(playerTransform.position, Vector3.up, -300 * Time.deltaTime); 
		}
			
	}
}

