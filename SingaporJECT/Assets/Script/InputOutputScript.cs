﻿using UnityEngine;
using System.Collections;
using System.IO; //we're using input output for this game. Awesome!
using UnityEngine.UI; //we're also using Unity's UI!

public class InputOutputScript : MonoBehaviour {

	//QUESTIONS
	//Why isn't it reading line 17 correctly?

	//THINGS WHICH NEED TO BE IMPLEMENTED
	//1. On game start, you click the button to select a random line of text.
	//2. Implement text box input
	//3. Implement text box indicator of remaining characters.
	//4. When you click the button, it puts the text into the file and selects another random line.

	//HERE'S EVERYTHING WE NEED TO COMMUNICATE WITH
	public InputField inputField;
	public Text instructionText;
	public Text previousText;
	public Text followingText;
	public Button insertTextButton;

	//ALL OF THESE ARE CONSTANTS SO TYPOS ARE CAUGHT EASILY
	private const char delim = '|'; //this is our delimiter. Unity will recognize it as a break between things.
		//I think that the way I've designed this, a delimiter is unecessary, but we can't stop now. We've gone TOO FAR.
		//I totally undid it by making the delim a space. We can undo my undoing it with ease.
	private const string PATH = "Assets/Once40End/"; //this is where we'll store our stories
	private const string FILE_NAME = "firstStory.txt"; //this is the name of the file
		//ideally, this would be initialized later on so players could create and name their own stories.
		//For this exercise, I'm just making one story.
	private const string TEMP = "temp.txt"; //I'm unhappy that this exists.

	//I tried making a line break a delimiter. It didn't work as I intended.
	//	private const string delim = "\r\n";

	public string PLAYER_NAME = null; //this is the player's name.
		//ideally, I use this. If not, I tried.

	int currentLine; //the line we're currently reading
	string streamInput; //this is the most recent line read by our StreamReader

	// Use this for initialization
	void Start () {
		//create and populate a new story. This will erase an existing file.
		CreateNewStory ();

		RewriteEverythingAndChangeThisOneLine ("Testing!", 2);
		ReadThisLine (1);
		ReadThisLine (2);

		instructionText.text = "Welcome to Once40 End.\nYou'll be collaborating with other players to create a 40 line story.\nIt starts with \"Once upon a time.\" and ends with \"The End.\" It's up to you to write the rest.";
		previousText.text = "";
		followingText.text = "";

		ReadThisLine (3);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void CreateNewStory(){
		//I'm using this to brute force create a new document
		StreamWriter sw = new StreamWriter (PATH + FILE_NAME, false);
		for (int i = 1; i < 41; i++) {
			//convert i into a stream. Research is awesome!
			string s = i.ToString ();
			if (i == 1) {
				//if it's the first line, we begin the story
				sw.WriteLine (s + ": Once Upon a Time," + delim);
			} else if (i == 40) {
				//if it's the last line, we end the story
				sw.WriteLine (s + ": The End." + delim);
			} else {
				//otherwise, we make a blank line
				sw.WriteLine (s + ":" + delim);
			}
		}
		sw.Close();
		Debug.Log ("Erased the old story.");

	}

	//Load the desired line of text from the story file
	void ReadThisLine (int lineNumber){

		//First, we need to open a stream to the file
		//The inputs are the file's path and file's name. Constant names are awesome.
		StreamReader sr = new StreamReader (PATH + FILE_NAME);

		//if we're trying to read something beyond the last line, we read the last line
		if (lineNumber > 39) {
			lineNumber = 39;
		}

		//We'll read the stream until we get to the desired line.
		//Remember that i is starting at 0. If we want to read line 37, we'll do so when i = 36.
		//We also want to read the previous and following lines.
		//We'll stop running this once we've read one past the desired line.
		for (int i = 0; i < lineNumber+1; i++) {
			streamInput = sr.ReadLine ();

			if (i == lineNumber - 2) {
				//when you're at the previous line, mark it
				previousText.text = "Previous line: \"" + streamInput + "\"";
			}
			if (i == lineNumber - 1) {
				//when you're on the desired line, print it to the console
				Debug.Log ("LINE " + lineNumber + " READ! It says, \"" + streamInput + "\"");
			}
			if (i == lineNumber) {
				followingText.text = "Following line: " + streamInput + "\"";
			}

		}



		//remove the delimiter from the string. Am I just wasting time with a delimiter?
		//I want the .txt. file itself to be readable as a story.
//		string[] splitInput = streamInput.Split(new char[]{delim});
//		Debug.Log ("Split string: " + splitInput[1]);

		//Now that we're done writing, close the stream.
		sr.Close();

	}


	//This may be stupid and inelegant, but I'm having trouble finding what I want on the internet.
	//So, here's what we're going to do.
	//We're going to read THE ENTIRE FILE. Every line that we want to keep, we'll copy into a separate document.
	//When we get to the line we want, we'll write what we want.
	//Then we'll keep going to the end.
	//Then we'll OVERWRITE THE ORIGINAL DOCUMENT and put in all the data we just copied into the temporary document.
	//This seems dumb.
	void RewriteEverythingAndChangeThisOneLine(string textInput, int lineNumber){
		//First, we'll transpose our story into a temp document.

		//We'll need to read the stream of our original document
		StreamReader sr1 = new StreamReader (PATH + FILE_NAME);
		//We'll also need to write a stream to our temp document
		StreamWriter sw1 = new StreamWriter (PATH + TEMP, false);
		//I'm too upset to use streamInput. It didn't ask for this.
		string tempStreamOutput;

		//Let's transpose our old document into our new document
		for (int i = 0; i < 40; i++){
			tempStreamOutput = sr1.ReadLine();
			if(i == lineNumber){
				//if we're on the line we want, we write the new input
				string s = i.ToString ();
				sw1.WriteLine(s + ": " + textInput + delim);
				Debug.Log ("Changed line " + s + " to \"" + textInput + "\"");
			}else {
				//otherwise, we just copy the story into the temp document
				sw1.WriteLine(tempStreamOutput);
			}
		}
		//Don't forget to close your streams.
		sr1.Close();
		sw1.Close();

		//Now, let's do it all over again and transpose temp into the story document.
		StreamReader sr2 = new StreamReader (PATH + TEMP);
		StreamWriter sw2 = new StreamWriter (PATH + FILE_NAME, false);
		for (int i = 0; i < 40; i++){
			//otherwise, we just copy the story into the temp document
			tempStreamOutput = sr2.ReadLine();
			sw2.WriteLine(tempStreamOutput);
		}
		//Don't forget to close your streams.
		sr2.Close();
		sw2.Close();

		Debug.Log ("Transpose complete.");
	}
		
	//Select a random line from the text
	void SelectRandom(){
		int tempNumber = Random.Range (2, 39);
		//if this would move us to a different line, do it!
		if (currentLine != tempNumber) {
			currentLine = tempNumber;
		//if we'd instead stay on the same line, try again
		} else {
			//this is recursive, I know
			SelectRandom ();
		}
	}
}
