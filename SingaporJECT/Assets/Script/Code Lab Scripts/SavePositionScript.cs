using UnityEngine;
using System.Collections;
using System.IO; //we're using input/output

public class SavePositionScript : MonoBehaviour {

	public KeyCode spacebar; //we need to recognize an input in order to save the game
	public const string PATH = "Assets/Resources/";
	public string savePosFile; //this is public. We need to name it in the inspector.
	public const char DELIM = '|';

	// Use this for initialization
	void Start () {
		//the first time we load up, we don't try to access something we haven't created yet
		if (File.Exists (PATH + savePosFile)) {
			//open a streamreader to a file
			StreamReader sr = new StreamReader (PATH + savePosFile);
			//read a line from the file. There's only one line. 
			string input = sr.ReadLine (); 	// "0|1|2"
			Debug.Log ("input: " + input);
			//split the file into individual values
			string[] posStringSplits = input.Split (new char[]{DELIM}); // ["0", "1", "2"]
			Vector3 newPos = new Vector3 (
				                 float.Parse (posStringSplits [0]), //x 0
				                 float.Parse (posStringSplits [1]), //y 1
				                 float.Parse (posStringSplits [2])  //z 2
			                 );
			transform.position = newPos;
			sr.Close ();
		}
	}
	
	// Update is called once per frame
	void Update () {

		//If I press the spacebar
		if (Input.GetKeyDown (KeyCode.Space)) {
			StreamWriter sw = new StreamWriter (PATH + savePosFile, false);
			//Save the current position of the object
			//to a file
			sw.WriteLine("" + //we're adding a string here so that it adds EVERYTHING as a string.
				//If it sees a float first, it'll add the ASCII values of the delim to the float. That's silly.
				transform.position.x + DELIM +
				transform.position.y + DELIM +
				transform.position.z);
			sw.Close ();
		}
	}
}
