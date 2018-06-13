using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

	private CharacterController controller;

	[Range(1.0f, 10.0f)] 
	public float speed = 5.0f; 

	void Start ()
	{
		controller = GetComponent<CharacterController>(); 
	}
	
	void Update ()
	{
		
		controller.Move((Vector3.forward * speed) * Time.deltaTime); 
	}
}
