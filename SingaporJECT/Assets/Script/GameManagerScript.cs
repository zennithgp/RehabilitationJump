using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; //we'll be using the GameManager to load scenes

public class GameManagerScript : MonoBehaviour {

	//WE LEARNED THE FOLLOWING IN WEEK 3:
	//SINGLETONS
	//CONSTANTS
	//AWAKE
	//PROPERTIES
		//GET
		//SET
	//DEBUGGING
	//we also covered loading scenes... something I'd never done in Unity before. ...yeah

	//SINGLETONS
	public static GameManagerScript gameManager = null;
	//hey, we're making a singleton!
	//as a reminder, we're giving our gameManagers a name
	//when they wake, if they see something else with their name, apoptosis! Hooray!


	public string nextScene; //we can input the name of our next scene
	//DON'T FORGET TO ADD THAT SCENE TO YOUR BUILD SETTINGS.
	//IF YOU DON'T, IT WON'T LOAD.


	//CONSTANTS
	private const int MAX_JUMP_HEIGHT = 100; //we're making a constant
	//this variable can accessed, but never changed

	//PROPERTIES
	private int score; //a private variable which can be accessed via properties
	//remember, the convention for properties is to be upper-cased

	public int Score {
		get { //the get allows other game objects to access the private variable, score
			Debug.Log ("The current score is: " + score);
			return score; //this gives the score to whatever accessed it
		}
		set { //the set allows other game objects to change the private variable, score
			Debug.Log ("Score changed! Previous score: " + score + ". The new score is: " + value);
			score = value; //value is whatever was used to modify this property

			if (score == 50) {//the maximum high score is 10
				Debug.Log ("Level complete.");
				SceneManager.LoadScene (nextScene); //load the next scene
			}
		}
	}
	

	//AWAKE
	//Awake is called when the script instance is loaded. It happens before Start.
	void Awake(){
		DontDestroyOnLoad (gameObject); //don't destroy this game object when a scene loads

		if (gameManager == null) {//if we don't already have a gameManager
			gameManager = this;//then now we do!
		} else { //if we already have a gameManager
			Destroy (gameObject); //we have this commit apoptosis
		}
	}


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Score++;

		//I debugged. It was neat.
//		Debug.Log ("Let's test this out.");
//
//		Debug.Log ("Is it really that hard?");
//
//		Debug.Log ("ImagePosition switch AreaEffector2D  WebCamFlags");
//
//		Debug.Log ("Man, autocorrect is weird.");
	}
}
