using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour 
{
	public float roll = 0f;

	private float jumpUp = .5f;
	private float jumpDown = .5f;

	//turn speeds

	//left
	private float standLTurnSpeed;
	private float standLMaxTurnSpeed;
	private float standLMinTurnSpeed;
		//4/4
		private float fourLTurnSpeed;
		private float fourLMaxTurnSpeed;
		private float fourLMinTurnSpeed;
		//3/4
		private float threeLTurnSpeed;
		private float threeLMaxTurnSpeed;
		private float threeLMinTurnSpeed;

	//right
	private float standRTurnSpeed;
	private float standRMaxTurnSpeed;
	private float standRMinTurnSpeed;
		//2/4
		private float twoRTurnSpeed;
		private float twoRMaxTurnSpeed;
		private float twoRMinTurnSpeed;
		//1/4
		private float oneRTurnSpeed;
		private float oneRMaxTurnSpeed;
		private float oneRMinTurnSpeed;


	void Start () 
	{
		standLTurnSpeed = this.GetComponent<PlayerMovement> ().leftTurnSpeed; 
		standLMaxTurnSpeed = this.GetComponent<PlayerMovement>().leftMaxTurnSpeed;
		standLMinTurnSpeed = this.GetComponent<PlayerMovement>().leftMinTurnSpeed;

		standRTurnSpeed = this.GetComponent<PlayerMovement> ().rightTurnSpeed; 
		standRMaxTurnSpeed = this.GetComponent<PlayerMovement>().rightMaxTurnSpeed;
		standRMinTurnSpeed = this.GetComponent<PlayerMovement> ().rightMinTurnSpeed;

		fourLTurnSpeed = standLTurnSpeed += jumpUp; //4/4quad
		fourLMaxTurnSpeed = standLMaxTurnSpeed += jumpUp;
		fourLMinTurnSpeed = standLMinTurnSpeed += jumpUp;

		threeLTurnSpeed = standLTurnSpeed -= jumpDown; //3/4quad
		threeLMaxTurnSpeed = standLMaxTurnSpeed -= jumpDown;
		threeLMinTurnSpeed = standLMinTurnSpeed -= jumpDown;

		twoRTurnSpeed = standRTurnSpeed -= jumpUp; //2/4quad
		twoRMaxTurnSpeed = standRMaxTurnSpeed -= jumpUp;
		twoRMinTurnSpeed = standRMinTurnSpeed -= jumpUp;

		oneRTurnSpeed = standRTurnSpeed += jumpDown; //1/4quad
		oneRMaxTurnSpeed = standRMaxTurnSpeed += jumpDown;
		oneRMinTurnSpeed = standRMinTurnSpeed += jumpDown;
	}
	

	void Update () 
	{
		RollInput ();

		Checking ();
	}

	void RollInput ()
	{
		if (Input.GetKey(KeyCode.E)) //rolling right -- increasing
		{
			roll += rollScale;
		}

		if (Input.GetKey (KeyCode.Q)) //rolling left -- decreasing
		{
			roll -= rollScale;
		}

		//Left
		if (roll < 0 && roll > -90)  //jump up
		{
			leftMaxTurnSpeed += rollJumpUp;
			leftMinTurnSpeed += rollJumpUp;
			leftTurnSpeed += rollJumpUp;
		}
		if (roll < -90 && roll > -180) //jump down 
		{
			leftMaxTurnSpeed -= rollJumpDown;
			leftMinTurnSpeed -= rollJumpDown;
			leftTurnSpeed -= rollJumpDown;
		}

		//Right
		if (roll > 0 && roll < 90) //jump up
		{
			rightMaxTurnSpeed += rollJumpUp;
			rightMinTurnSpeed += rollJumpUp;
			rightTurnSpeed += rollJumpUp;
		}
		if (roll > 90 && roll < 180) //jump down
		{
			rightMaxTurnSpeed -= rollJumpDown;
			rightMinTurnSpeed -= rollJumpDown;
			rightTurnSpeed -= rollJumpDown;
		}
	}


	void Checking ()
	{
		//roll check
		if (roll > 180) //right max roll (POSITVE)
		{
			roll = -180f; //turns negative 
		}
		if (roll < -180) //left max roll (NEGATIVE)
		{
			roll = 180; //turns positive
		}
	}
}
