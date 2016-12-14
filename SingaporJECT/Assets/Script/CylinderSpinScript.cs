using UnityEngine;
using System.Collections;

public class CylinderSpinScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, 10);
//		Vector3 tempRotation = new Vector3 (transform.rotation.x, transform.rotation.y, transform.rotation.z + 4);
//		transform.rotation = tempRotation;
	}
}
