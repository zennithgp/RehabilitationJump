using UnityEngine;
using System.Collections;
using System.IO; //INPUT OUTPUT!

public class FileIOScript : MonoBehaviour {

	private const char delim = '|'; //we're making our delimiter a constant. THIS IS SO IMPORTANT.
	private const string PATH = "Assets/";
	private const string FILE_NAME = "test.txt";

	// Use this for initialization
	void Start () {


		//Opens a stream to a file.
		//first parameter is the path, the second is whether or not to append (if it doesn't append to the end, it replaces the file)
		StreamWriter sw = new StreamWriter (PATH + FILE_NAME, false);

		//Write a line to the file
		sw.WriteLine ("MAD" + delim + "1000" + delim + "4"); //we're using Pipe characters to separate information.
			//when we read this out, we want to be able to split this out

//		sw.WriteLine ("Hello World.");
//		sw.WriteLine ("This is the next line.");
//		sw.WriteLine ("This is on a line.\r\nThis is on another.");
			//I'm using \r\n for a line break because Windows and Notepad are awkward
			//If we want to put a backslash in our code, we need to put two in, like so: "\\". It will output as \.
			//To use special characters, like quotes or a backslash, we preface them with a backslash.
			//This is known as "escaping" a character.

		//Once we're done writing, we close our stream
		sw.Close();


		//Opens a stream to a file
		//The parameter is the path to the file
		StreamReader sr = new StreamReader (PATH + FILE_NAME);

		//Read a line from the file
//		Debug.Log("Line from file: " + sr.ReadLine()); //this is concatenating two strings

		//Split up a concatenated string
		string input = sr.ReadLine ();
		Debug.Log (input);
		string[] splitInput = input.Split(new char[]{delim});
			//single quotes means a character
			//double quotes means a string
		Debug.Log("Name: " + splitInput[0]); //this should just print out MAD

		//Once we're done writing, we close our stream
		sr.Close();



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
