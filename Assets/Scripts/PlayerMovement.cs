using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

	//move speed
	public float moveSpeed = 3f;
	private float maxMoveSpeed = 15f;
	private float minMoveSpeed = 3f;
	
	//turn speed
	public float rightTurnSpeed = 1f; //start
	public float leftTurnSpeed = 1f; //start
	private float rightMaxTurnSpeed = 1f; //max
	private float leftMaxTurnSpeed = 1f; //max
	private float rightMinTurnSpeed = .2f; //min
	private float leftMinTurnSpeed = .2f; //min

	//rolling
	public float roll = 0;
	public float maxRoll = 360;

	//scaling logic
	private float moveScale = .8f;
	private float turnScale = .1f;

	private float scaleTimer = 0f;
	private float startScaleTimer = .3f;
	
 	Rigidbody2D rb; //the plane
	
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		scaleTimer = startScaleTimer;
	}

	private void FixedUpdate() //movement my man
	{
		rb.MovePosition(transform.position + transform.up * Time.deltaTime * moveSpeed); //this is the working move forwards line. (this is the line that will actuallymove the object forward
	}

	void Update () 
	{
		MainMovement ();

		Rolling ();

		Checking ();
	}

	void MainMovement ()
	{
		
		if (Input.GetKey(KeyCode.D)) // turning the aircraft to the RIGHT
		{
			transform.Rotate(new Vector3(0, 0, -1) * rightTurnSpeed);
		}

		if (Input.GetKey(KeyCode.A)) //turning the aircraft to the LEFT
		{
			transform.Rotate(new Vector3(0, 0, 1) * leftTurnSpeed);
		}

		if (Input.GetKey(KeyCode.P)) //adding speed
		{
			scaleTimer -= Time.deltaTime;
			if (scaleTimer <= 0 && moveSpeed < maxMoveSpeed) //checking if it's less than the max
			{
				moveSpeed += moveScale; //adding
				if (rightTurnSpeed < rightMaxTurnSpeed) //checking if it's less than the max
				{
					rightTurnSpeed -= turnScale; //smaller turning radius
				}
				if (leftTurnSpeed < leftMaxTurnSpeed) 
				{
					leftTurnSpeed -= turnScale; //smaller turning radius
				}
				scaleTimer = startScaleTimer; //reset 
			}
		}

		if (Input.GetKey(KeyCode.L)) //subtracting speed
		{
			scaleTimer -= Time.deltaTime;
			if (scaleTimer <= 0 && moveSpeed > minMoveSpeed) //checking if it's more than the min
			{
				moveSpeed -= moveScale; //subtracting
				if (rightTurnSpeed < rightMaxTurnSpeed) //checking if it's less than the max
				{
					rightTurnSpeed += turnScale; //smaller turning radius
				}
				if (leftTurnSpeed < leftMaxTurnSpeed) 
				{
					leftTurnSpeed += turnScale; //smaller turning radius
				}
				scaleTimer = startScaleTimer; //reset
			}
		}
	}

	void Rolling ()
	{
		if (Input.GetKey(KeyCode.E)) //rolling right
		{

		}
	}

	void Checking ()
	{
		//checking
		if (rightTurnSpeed < rightMinTurnSpeed) //right min
		{
			rightTurnSpeed = rightMinTurnSpeed;
		}

		if (leftTurnSpeed < leftMinTurnSpeed) //left min
		{
			leftTurnSpeed = leftMinTurnSpeed;
		}

		if (rightTurnSpeed > rightMaxTurnSpeed) //right max
		{
			rightTurnSpeed = rightMaxTurnSpeed;
		}

		if (leftTurnSpeed > leftMaxTurnSpeed) //left max
		{
			leftTurnSpeed = leftMaxTurnSpeed;
		}

		if (moveSpeed < minMoveSpeed) //min speed
		{
			moveSpeed = minMoveSpeed;
		}

		if (moveSpeed > maxMoveSpeed) //max speed
		{
			moveSpeed = maxMoveSpeed;
		}
	}
}
