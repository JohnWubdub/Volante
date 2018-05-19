using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public GameObject plane;
	
	void Start () 
	{
		
	}
	

	void Update ()
	{
		transform.position = new Vector3(plane.transform.position.x, plane.transform.position.y, -10);
	}
}
