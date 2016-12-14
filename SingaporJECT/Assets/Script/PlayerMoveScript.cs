﻿using UnityEngine;
using System.Collections;

public class PlayerMoveScript : MonoBehaviour {

	//this script is for player movement, as the name suggests

	//we have a PUBLIC float for speed, so don't forget to change it in the inspector
	public float speed;
	public float jumpSpeedMultiplier; //the multiplier of your walking speed for jumps

	//we're creating names for keys. We can plug our desired keys into the inspector.
	//because this script is written so open-ended, we can reuse it throughout Code Lab One.
	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;
	//I added movement in the Z directions, even though it wasn't in the initial script. It works.
	public KeyCode zoomIn;
	public KeyCode zoomOut;
	public KeyCode jump; //added this for a jump

//	bool canJump; //Zach needs to learn/relearn some basics physics stuff, like gravity and collisions. Until then, bogus physics!
//	bool jumpingNow; //bool to track if you're currently jumping


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		if (txtLevelCreatorScript.gameStart) {

			//we're adjusting our speed for time. This saves us the trouble of using Time.deltaTime everywhere.
			float timeAdjustedSpeed = speed * Time.deltaTime;

			//MoveByKey is a function that'll saves us a lot of code.
			//The first parameter refers to an aforementioned KeyCode
			//The second parameter is a Vector3. That's how we'll move.
			MoveByKey (up, new Vector3 (0, timeAdjustedSpeed, 0));
			MoveByKey (left, new Vector3 (-timeAdjustedSpeed, 0, 0));
			MoveByKey (down, new Vector3 (0, -timeAdjustedSpeed, 0));
			MoveByKey (right, new Vector3 (timeAdjustedSpeed, 0, 0));
			//because this is fun!
			MoveByKey (zoomIn, new Vector3 (0, 0, -timeAdjustedSpeed));
			MoveByKey (zoomOut, new Vector3 (0, 0, timeAdjustedSpeed));
		}
	}

	//here's the MoveByKey function we just talked about.
	void MoveByKey (KeyCode key, Vector3 movement){
		//if we have the input we programmed it to recognize...
		if (Input.GetKey (key)) {
			transform.position += movement; //we move in the direction we programmed it to move! Huzzah!
		}
	}

//	void JumpByKey (KeyCode key, Vector3 movement){
//				if(Input.GetKey (key) && canJump){ //if you're pressing the jump key, you're allowed to jump
//
//				}
//	}

	public void IncreaseSpeed(float spd){
		//I made this so that I can increase the player's speed.
		speed += spd;
	}
		
}


//this is a bunch of older code. We don't need it anymore, but I'm leaving it here to remember how we used to do things.

//		MoveByKey (KeyCode.W, new Vector3( 0, timeAdjustedSpeed, 0));
//		MoveByKey (KeyCode.A, new Vector3(-timeAdjustedSpeed, 0, 0));
//		MoveByKey (KeyCode.S, new Vector3(0, -timeAdjustedSpeed, 0));
//		MoveByKey (KeyCode.D, new Vector3( timeAdjustedSpeed, 0, 0));
//		//because this is fun!
//		MoveByKey (KeyCode.Z, new Vector3(0, 0, -timeAdjustedSpeed));
//		MoveByKey (KeyCode.X, new Vector3(0, 0,  timeAdjustedSpeed));




//		if (Input.GetKey (KeyCode.A)) {
//			Debug.Log ("Pressed A");
//			Vector3 newPos = new Vector3 (transform.position.x - speed * Time.deltaTime,
//			                              transform.position.y,
//			                              transform.position.z);
//			transform.position = newPos;
//		}

		//alternate option
//		if (Input.GetKey (KeyCode.A)) {
//			transform.position += new Vector2 3 (-speed * Time.deltaTime, 0, 0);
//		}
//
//		if (Input.GetKey ("s")) {
//			Vector3 newPos = new Vector3 (transform.position.x,
//			                              transform.position.y - speed * Time.deltaTime,
//			                              transform.position.z);
//			transform.position = newPos;
//		}
//
//		if (Input.GetKey ("d")) {
//			Vector3 newPos = new Vector3 (transform.position.x + speed * Time.deltaTime,
//			                              transform.position.y,
//			                              transform.position.z);
//			transform.position = newPos;
//		}
//
//		if (Input.GetKey ("w")) {
//			Vector3 newPos = new Vector3 (transform.position.x,
//			                              transform.position.y + speed * Time.deltaTime,
//			                              transform.position.z);
//			transform.position = newPos;
//		}
//
//		if (Input.GetKey ("x")) {
//			Vector3 newPos = new Vector3 (transform.position.x,
//			                              transform.position.y,
//			                              transform.position.z + speed * Time.deltaTime);
//			transform.position = newPos;
//		}
//
//		if (Input.GetKey ("z")) {
//			Vector3 newPos = new Vector3 (transform.position.x,
//			                              transform.position.y,
//			                              transform.position.z - speed * Time.deltaTime);
//			transform.position = newPos;
//		}