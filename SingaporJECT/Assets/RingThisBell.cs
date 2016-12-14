using UnityEngine;
using System.Collections;

public class RingThisBell : MonoBehaviour {

	GameObject player;
	AudioSource bellRing;
	//bool to track if you've touched this already
	bool touchedTheEnd;
	PlayerPhysicsMoveScript playerPhysicsMoveScript;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		bellRing = GetComponent<AudioSource> ();
		playerPhysicsMoveScript = player.GetComponent<PlayerPhysicsMoveScript> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collider){
		if (collider.gameObject.name == "Player" && touchedTheEnd == false) {
			bellRing.Play ();
			touchedTheEnd = true;
//			gameManagerScript.CheckHighScore ();
			Invoke ("AdvanceLevel", 2f);
		}
	}

	void AdvanceLevel(){
		playerPhysicsMoveScript.ResetPlayerPosition (true);
	}

}
