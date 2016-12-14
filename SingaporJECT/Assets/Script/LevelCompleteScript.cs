﻿using UnityEngine;
using System.Collections;

public class LevelCompleteScript : MonoBehaviour {

	//this is a bool which tracks if this is your first time touching the end of the level
	//if it is, great! you've done it!
	//if it's not, you're colliding with multiple end level blocks and I want to keep the game from bugging out
	public static bool touchedTheEnd = false;

	public GameObject player;
	public GameObject gameManager;
	public AudioSource winMusic;
	AudioSource levelMusic;
	MidtermGameManager gameManagerScript;

	// Use this for initialization
	void Start () {
	
		player = GameObject.Find ("Player");
		gameManager = GameObject.Find ("GameManager");
		winMusic = GetComponent<AudioSource> ();
		levelMusic = gameManager.GetComponent<AudioSource> ();
		gameManagerScript = gameManager.GetComponent<MidtermGameManager> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collider){
		if (collider.gameObject.name == "Player" && touchedTheEnd == false) {
			levelMusic.Stop ();
			winMusic.Play();
			touchedTheEnd = true;
			Debug.Log ("You touched the end?");
			gameManagerScript.CheckHighScore ();
			Invoke ("Restart", 4f);
		}

	}

	void Restart(){
		gameManagerScript.SwitchLevel ();
		gameManagerScript.Reset ();
		touchedTheEnd = false;
		winMusic.Stop ();
	}
}
