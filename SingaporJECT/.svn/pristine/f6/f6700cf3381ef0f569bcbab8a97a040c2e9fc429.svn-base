using UnityEngine;
using System.Collections;

public class SafeZoneMoveScript : MonoBehaviour {

	public float range;

	float offset;

	// Use this for initialization
	void Start () {

		offset = Random.Range (0, 10); //we're generating a random number so that the Perlin Noise starts each game with a different seed
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = new Vector3 ();

		//realtimeSinceStartup is a measure of how much time has passed since the game began
		newPos.x = (Mathf.PerlinNoise (Time.realtimeSinceStartup + offset, 0) * range) - (range/2);
		transform.position = newPos;

		newPos.y = (Mathf.PerlinNoise (0, Time.realtimeSinceStartup + offset) * range) - (range/2);
		transform.position = newPos;

	}
}