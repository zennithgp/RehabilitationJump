using UnityEngine;
using System.Collections;

public class W4GameManagerScript : MonoBehaviour {

	//REFACTORING 					IT'S AMAZING
	//PLAYERPREFS
	//STREAMWRITER
	//STREAMREADER
	//DELIMITER (|)

	private static W4GameManagerScript w4GM;

	public static W4GameManagerScript W4GM {
		get {
			if (w4GM == null) { //if w4GM was never assigned anything
				w4GM = GameObject.Find ("GameManager").GetComponent<W4GameManagerScript> (); //then we get a game object and pull its script
				DontDestroyOnLoad (w4GM); //even though this is a component, DontDestroyOnLoad preserves the ENTIRE HIERARCHY
			}
			return w4GM;

		}set{
			w4GM = value;
		}

	}

	private int score;

	public int Score{
		get{
			return score;
		}
		set{
			score = value;

			if (score > HighScore) { //if we get a score that's higher than our old PROPERTY high score
				HighScore = score; //make that PROPERTY high score equal to our score
			}
			Debug.Log ("Score: " + score + " HighScore: " + HighScore);
		}
	}

	private int highScore; //time to make a property!
	public int HighScore{
		get{
			highScore = PlayerPrefs.GetInt (KEY_SCORE); //get the high score from the player prefs
			return highScore;
		}
		set{
			highScore = value; //set a new high score
			PlayerPrefs.SetInt (KEY_SCORE, highScore); //and we automatically save it as soon as we set it
		}
	}

	//we're making a constant
	//it has a preface that describes the wide idea of what this is
	//then is has the name that explains what it does
	//this is a convention, not rule, but a good convention
	private const string KEY_SCORE = "SaveScore";

	// Occurs when the object is added to the scene
	void Awake(){
		if (w4GM != null) { //if w4GM has been set
			Destroy (gameObject); //destroy this instance
		} else { //otherwise
			Debug.Log("Setup Game Manager: " + W4GM); //setup W4GM by calling line 9
		}
	}

	// Use this for initialization
	void Start () {

		//this was built into Unity to quickly store player data
		//it's usually used for player preferences like music volume
		//it can also be used for storing high scores and the like
//		PlayerPrefs.SetInt(KEY_SCORE, 10);
		//when we comment out that line, as long as we've run it once, it's still saved as 10!

		Debug.Log (PlayerPrefs.GetInt (KEY_SCORE));

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
