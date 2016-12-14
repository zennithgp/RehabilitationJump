using UnityEngine;
using System.Collections;

public class CircleCollisionCheckScript : MonoBehaviour {

	public GameObject safeZone;
	public float maxSafeDistance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//this checks if the two objects are a certain distance apart
		if (Vector3.Distance (transform.position, safeZone.transform.position) > maxSafeDistance) {
			Destroy (gameObject); //this is a reference to whatever game object this script is on
		}
	}
}
