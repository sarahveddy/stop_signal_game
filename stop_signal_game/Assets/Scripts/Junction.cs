using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junction : MonoBehaviour {

	private GameObject gameObject; 
	
	private bool stopTrial;
	private char direction; //'r' if right is the correct choice, 'l' if left is the correct choice
	private float timeBefore; //this is the ammount of time before the stimulus is shown
	private float pathLength; //the length of the path 
	    
	public Junction(bool stopTrial, char dir, float time, float len)
	{
		//TODO: check the input - throw errors
		this.stopTrial = stopTrial;
		this.direction = dir;
		this.timeBefore = time;
		this.pathLength = len; 
		//TODO: add length of path (a function of timeBefore and speed)
	}

	public bool isStopTrial()
	{
		return this.stopTrial; 
	}

	public float getPathLength()
	{
		return this.pathLength; 
	}
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
