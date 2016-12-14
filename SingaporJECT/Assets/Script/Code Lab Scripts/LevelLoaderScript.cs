using UnityEngine;
using System.Collections;
using System.IO;

public class LevelLoaderScript : MonoBehaviour {

	public string levelFile;

	private const string BLOCK_PATH = "Block";
	public Vector3 offset;

	GameObject levelHolder;

//	string levelLine1 = "xxxxx";
//	string levelLine2 = "x---x";

	string[] levelStringArray = new string[]{
//		"xxxxx",
//		"x---x",
//		"x--xx",
//		"xxxxx"
	};

	// Use this for initialization
	void Start () {

		//we're making a wrapper so we don't clutter our scene with blocks
		levelHolder = new GameObject ("Level Holder");

		//Instantiate a game object with a position and rotation
//		Instantiate(Resources.Load(BLOCK_PATH));

		StreamReader sr = new StreamReader (SavePositionScript.PATH + levelFile);
		string fileContents = sr.ReadToEnd ();

		//we're reading and splitting the contents into an array
		levelStringArray = fileContents.Split('\n');

		//Here, we're going to BLOW YOUR MIND.
		//We're going to read each element of the levelStringArray
		//Wherever we find an x, we instantiate a block
		for (int i = 0; i < levelStringArray.Length; i++) {
			LevelString (levelStringArray [i], -i);
		}


		sr.Close ();
}



	// Update is called once per frame
	void Update () {
	
	}

	void LevelString(string line, float yPos){

//		char[] chars = line.ToCharArray ();

		for (int i = 0; i < line.Length; i++) {
			char c = line [i];
			Debug.Log ("Char at " + i + ": " + c);

			if (c == 'x') {
				GameObject block = Instantiate (Resources.Load (BLOCK_PATH) as GameObject);
								//"as GameObject" is CASTING. It's telling the function to return a GameObject.
				block.transform.position = new Vector3 (i, yPos, 0) + offset;
				block.transform.parent = levelHolder.transform;
			}
		}

	}
}