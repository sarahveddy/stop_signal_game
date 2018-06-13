using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CameraMotor : MonoBehaviour
{
	//private variables
	private Transform playerTransform;
	private Vector3 startOffset;
	private Vector3 moveVector;

	private float transition = 0.0f;
	private float animationDuration = 2.0f; //TODO: put this in the same place as the animationDuration var in PlayerMotor
	private Vector3 animationOffset = new Vector3(0, 5, 5);
	 
	
	
	void Start ()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		startOffset = transform.position - playerTransform.position; 
	}
	

	void Update ()
	{
		moveVector = playerTransform.position + startOffset;
	
		//X - left and right
		moveVector.x = 0; //keeps the camera from moving side to side with the player
		
		//Y - up and down
		//TODO: remove/change this if needed
		moveVector.y = Mathf.Clamp(moveVector.y, 3.0f, 5.0f); //restricts the y movement 
		
		//small animation at start of game
		if (transition > 1.0f)
		{
			transform.position = moveVector;	//normal movement
		}
		else
		{
			transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
			transition += Time.deltaTime * 1 / animationDuration; 
			transform.LookAt(playerTransform.position + Vector3.up);
		}
		
		
		
	}
}
