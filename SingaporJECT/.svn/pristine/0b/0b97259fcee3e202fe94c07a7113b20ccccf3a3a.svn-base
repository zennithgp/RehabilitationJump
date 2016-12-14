using UnityEngine;
using System.Collections;

public class OrbitScript : MonoBehaviour {

	public Transform orbitTarget;
	public Vector3 axis = Vector3.up;
	public float speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.RotateAround (orbitTarget.position, axis, speed * Time.deltaTime);

	}
}
