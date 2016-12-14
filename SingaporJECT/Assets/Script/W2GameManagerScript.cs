using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; //we're using the scene manager to load scenes

public class W2GameManagerScript : MonoBehaviour {

	private int score;	//a variable to contain our score
						//it's private, so it can only be seen or modified in this class (which is a script)
						//if it were public, so we could see and modify it everywhere

	public string winScene; //we'll use this to load the name of the next scene

	public static W2GameManagerScript gameManager = null; //there's one static variable for our game manager
	//we'll use this to make sure we have a game manager in all of our scenes
	//we'll have a game manager in each individual scene for testing purposes,
	//but when we run the game, we'll have one game manager persisting across the game
	//and we DON'T want to have each scene add a new game manager

	private const int MAX_HEALTH = 100;
	//const means that this is a CONSTANT
	//we can use it, but we can't change it
	//the convention for constants is to use all caps. You use underscores, because you can't camel case.

	public int health;

	public int Health {
		get{
			return health;
		}
		set{
			health = value;

			if(health > MAX_HEALTH){
				health = MAX_HEALTH;
			}
		}
	}


	//in C#, things have properties!
	//the convention is to have a lower case for the private variable and an upper case for its property
	public int Score {
		//generates a get for the score variable
		get{
			Debug.Log ("Someone accessed the score: " + score);
			return score;
		}

		//generates a set for the score variable
		//if we want things to access the score, but not change it, we can remove the set property
		set{
			Debug.Log ("Score changed, old: " + score + " new: " + value);

			score = value; //value is whatever has been used to modify this propery
			
			if(score == 100){//there's a maximum high score of 100
				Debug.Log ("YOU WIN!!!");
				SceneManager.LoadScene(winScene); //this will work once I update Unity
			}
		}
	}

	//AWAKE IS CALLED WHEN THE SCRIPT INSTANCE IS BEING LOADED, EVEN IF THE SCRIPT COMPONENT IS NOT ENABLED
	void Awake(){
		//this is a specific function Unity is looking for, so we need to name it precisely


		//here, we're making the game manager a SINGLETON. there will be ONLY ONE.
		DontDestroyOnLoad (gameObject); //don't destroy this game object

		if (gameManager == null) { //if we don't have a game manager already...
			gameManager = this; //this current gameObject is our game manager
		} else { //otherwise, we already have a game manager!
			Destroy (gameObject); //and we don't need this one, so we destroy it
		}

	}

//	void FixedUpdate(){
//	}

	//START IS CALLED WHEN THE OBJECT ENTERS THE SCENE. IT'S ONLY CALLED WHEN THE SCRIPT COMPONENT IS ENABLED.
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		int i = Score; //every time this fires, we fire the get property and pull up a debug message
//		Score = 7; //this uses the set property
		Score++; //this still triggers the set function within the property
			//we've set a break point here, stopping the code at this line.
		SayHello (); //we're using this demonstrate breaks and stepping-in/out when debugging
	}

	void SayHello(){
		Debug.Log ("Hello");

		Debug.Log ("How are you?");

		Debug.Log ("I am fine.");
	}
}