using UnityEngine;
using System.Collections;

public class ItemSelectionScript3D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
		//Camera.main is a shortcut for the camera in your screen. Thanks, Unity!
		//Camera is a static class. Main is a static variable.
		Vector3 camPos = Camera.main.transform.position;

		//this gives you a reference to the position of the mouse in SCREEN SPACE
		//it's a reference to an X and a Y on your sceen
		Vector3 mousePos = Input.mousePosition;
//		Debug.Log ("mousePos: " + mousePos);

		//the Z is the near clipping plane. We want out camera in the frustum (the space viewable by the camera).
		mousePos.z = Camera.main.nearClipPlane;

		//now, we need to convert the mouse's position into WORLD SPACE
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);

//		Debug.Log ("mousePos: " + mousePos);



		//we're getting a Vector 3 that's the distance between the two points
		Vector3 direction = mousePos - camPos;

		//we're normalizing the Vector3. reducing its *magnitude* to 1.
		direction.Normalize ();


		RaycastHit hitInfo = new RaycastHit ();

		if (Physics.SphereCast (camPos, 1, direction, out hitInfo)) {
			Debug.Log ("HIT SOMETHING: " + hitInfo.collider.name);
			//out hitInfo stores the value of whatever you've hit
			//under certain conditions, you'll update the values of the hitInfo object.
			//the function returns a true/false. If it's true, you know to look inside the function for what you hit.
		}
	
	}
}
