using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{

	private Transform playerTransform;
	private Vector3 startOffset; 
	
	void Start ()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		startOffset = transform.position - playerTransform.position; 
	}
	

	void Update ()
	{
		transform.position = playerTransform.position + startOffset;
	}
}
