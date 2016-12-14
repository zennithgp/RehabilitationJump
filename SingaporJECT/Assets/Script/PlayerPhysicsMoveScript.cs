using UnityEngine;
using System.Collections;

public class PlayerPhysicsMoveScript : MonoBehaviour {

	Rigidbody playerBody;


	public float speed = 1000f;

	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;
	public KeyCode moveIn;
	public KeyCode moveOut;
	public KeyCode reset;
	public Vector3[] startPos;
	int currentLevel = 0;
	public int startLevel = 0; //this is for me to cheat and test levels

	// Use this for initialization
	void Start () {
	
		playerBody = GetComponent<Rigidbody> ();
		currentLevel = startLevel;

	}
	
	// Update is called once per frame
	void Update () {
	
		//we're adjusting our speed for time. This saves us the trouble of using Time.deltaTime everywhere.
		float timeAdjustedSpeed = speed * Time.deltaTime;

		//MoveByKey is a function that'll saves us a lot of code.
		//The first parameter refers to an aforementioned KeyCode
		//The second parameter is a Vector3. That's how we'll move.
		MoveByKey (up, new Vector3 (0, timeAdjustedSpeed, 0));
		MoveByKey (left, new Vector3 (-timeAdjustedSpeed, 0, 0));
		MoveByKey (down, new Vector3 (0, -timeAdjustedSpeed, 0));
		MoveByKey (right, new Vector3 (timeAdjustedSpeed, 0, 0));
		MoveByKey (moveIn, new Vector3 (0, 0, timeAdjustedSpeed));
		MoveByKey (moveOut, new Vector3 (0, 0, -timeAdjustedSpeed));

		if (Input.GetKey (reset)) {
			ResetPlayerPosition (false);
		}

		CheatCodes ();
	}



	void MoveByKey (KeyCode key, Vector3 movement){
		if (Input.GetKey (key)) {
//			playerBody.MovePosition (movement);
//			Vector3 tempPosition = transform.position;
//			tempPosition += movement;
//			playerBody.MovePosition (tempPosition);
			playerBody.AddForce(movement); //we move in the direction we programmed it to move! Huzzah!
		}
	}

	void CheatCodes(){
		if (Input.GetKey (KeyCode.M)) {
			if (currentLevel < startPos.Length -1) {
				currentLevel++;
				Debug.Log ("The current level is " + currentLevel);
			}
		}
	}

	public void ResetPlayerPosition(bool advanceLevel){
		if (advanceLevel && currentLevel < startPos.Length-1) {
			currentLevel++;
		}
		transform.position = startPos[currentLevel];
		playerBody.velocity = startPos[0];
		playerBody.rotation.Set (0, 0, 0, 0);

	}

}
