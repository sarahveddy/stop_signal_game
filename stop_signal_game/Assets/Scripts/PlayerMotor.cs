using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

	//private variables
	private CharacterController controller;
	private Vector3 moveVector;
	private float verticalVelocity = 0.0f;
	private bool inputOn = false;
	private float animationDuration = 2.0f; //TODO: put this in the same place as the animationDuration var in CameraMotor
	

	
	//public variables
	[Range(1.0f, 10.0f)] 
	public float speed = 5.0f; 
	
	[Range(1.0f, 15.0f)] 
	public float gravity = 12.0f; // TODO
	

	void Start ()
	{
		controller = GetComponent<CharacterController>(); 
	}
	
	
	void Update ()
	{
		moveVector = Vector3.zero; //resets move vector

		if (controller.isGrounded)
		{
			verticalVelocity = -0.5f; //little push toward the ground
		}
		else
		{
			verticalVelocity -= gravity * Time.deltaTime; //falling down
		}

		if (Time.time > animationDuration)
		{
			//X - left and right
            moveVector.x = Input.GetAxisRaw("Horizontal") * speed; //TODO
		}
		
		
		//Y - up and down

		moveVector.y = verticalVelocity; //TODO
		
		//Z - forward and backward
		moveVector.z = speed; 
		
		controller.Move(moveVector * Time.deltaTime); 
	}


}

	

//TODO: remove/keep vertical and horizontal movement if needed. 