using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;

public class Once40EndStoryManager : MonoBehaviour {


	//HOLY CRAP, THAT WAS SO MUCH DEBUGGING FOR ONE STUPID LINE OF CODE.
	//Apparently, the StreamReader was appending when I told it not to and deleting the first line of the story every time it saved.
	//Three hours of debugging for one line of code. rrrrrRGH.

	/*So, here's what needs be done.
	 *When the game starts, it reads the text file and puts it into a list.
	 *You then move to a random line in the list between 2 and 39.
	 *The UI shows you the previous and following lines.
	 *When you click the button, it takes the text from the input file, updates that line from the list, and moves you to another line.
	 *When you click the save button, it saves the list back to the text file.
	 *
	 *
	 *Holy crap, we're done!
	 */

	//references to our UI
	public InputField inputField;
	public Text instructionText;
	public Text previousLine;
	public Text nextLine;
	public Text inputFieldText;
	public Text previouslyWrittenLineText;
	public Text playerName;
	public Button insertTextButton;

	//	private const char delim = '|';
	private const string FILE_NAME = "Assets/Resources/Once40Story.txt";
	private const string LAST_LINE_NAME = "Assets/Resources/Once40LastLine.txt";
	string previousWrittenLine;

	int currentLine;
	string thisLineSays;

	string storyFile; //I'm not sure this is pulling its weight. It's right now only there to check if it's null, and that doesn't work.
	public List<string> storyList; //we're using a LIST to contain the entire story. We'll use this to circumvent the streamwriter.

	// Use this for initialization
	void Start () {
	

		//Read the story file. If it doesn't exist, make a new one.
		Debug.Log ("Loading old story.");
		storyFile = FileIOUtility.ReadStringFromFile (FILE_NAME);
		//TODO: Make it actually check for a null file
		if (storyFile == null) {
			Debug.Log ("No story exists. Making new story.");
			MakeNewStory ();
		}

		//Recall the last line written
		previouslyWrittenLineText.text = "The last line written was: " + "\n\r" + FileIOUtility.ReadStringFromFile (LAST_LINE_NAME);

		//These are kind of self-explanatory
		TurnStoryIntoList ();
		SelectRandomLine ();

//		storyArray = storyFile.Split (new char{lineDelim});
//		storyArray = storyFile.Split (new string[] { "\r\n", "\n"\ }, StringSplitOptions.None);

	}
	
	// Update is called once per frame
	void Update () {
	
//		UpdateText ();

		if (Input.GetKeyDown (KeyCode.Alpha9)) {
			Debug.Log ("Using Debug Key 9");
//			MakeNewStory ();
		}

		if (Input.GetKeyDown (KeyCode.Alpha5)) {
//			Debug.Log (storyFile);
			Debug.Log("Using Debug Key 5");
//			SelectRandomLine();
//			Debug.Log("Story line 1: " + storyList[0]);
		}

	}

	void MakeNewStory(){
		//Erase the old story and make a new one

		//Write the first line and delete everything else in the story file
		FileIOUtility.WriteStringToFile (FILE_NAME, "1: Once Upon a Time", false);
		//Copy every other line into that file
		StreamWriter sw1 = new StreamWriter (FILE_NAME, true);
		for (int i = 2; i < 40; i++) {
			sw1.WriteLine (i.ToString () + ": (empty)");
		}
		//ALWAYS CLOSE YOUR STREAMS
		sw1.Close ();

//		FileIOUtility.WriteStringToFile (FILE_NAME, i.ToString() + ": test", true);

		//Add the last line to the file
		FileIOUtility.WriteStringToFile (FILE_NAME, "40: The End.", true);
		Debug.Log ("Erased the old story and made a new one.");
		//Update the string containing containing the story; this doesn't do much anymore
		storyFile = FileIOUtility.ReadStringFromFile (FILE_NAME);
		TurnStoryIntoList ();
	}

//	void TurnStoryInt	oList(string theStory){
//		theStory.Split(new char[]{'\n\r'}, 40);
//
//	}

	//AGH. Brute force, it is.

	void TurnStoryIntoList(){
		//Empty the story list
		storyList.Clear ();
		StreamReader sr1 = new StreamReader (FILE_NAME);
		for (int i = 0; i < 40; i++) {
			//Read every line of the story file and add it to the list
			storyList.Add (sr1.ReadLine ());
			Debug.Log ("Added line to story list: " + storyList [i]);
//			string tempString = sr1.ReadLine ();
//			storyList.Add (tempString);
		}
		sr1.Close ();
		//ALWAYS CLOSE YOUR STREAMS
	}

	void SelectRandomLine(){
		//Move to a random line of the story
		currentLine = Random.Range (2, 38);
		//update the line you're on and change the text displaying the previous and following lines
		thisLineSays = storyList [currentLine];
		previousLine.text = storyList [currentLine - 1];
		nextLine.text = storyList [currentLine + 1];
		if (storyList [currentLine].Contains ("(empty)")) {
			//If the storylist line is empty, awesome! Let's change it!
		} else {
			//If the line isn't empty, there's a 75% chance we'll skip it and select a new line
			int randomSeed = Random.Range (1, 4);
			if (randomSeed != 1) {
				SelectRandomLine ();
			}
		}
		Debug.Log (thisLineSays);
	}

	public void AddLineToStory(){
		//Add the contents of the text box to the story
		storyList [currentLine] = (currentLine+1) + ": " + inputFieldText.text  + " (" + playerName.text + ")";
		//Rewrite the current line of the story
		previouslyWrittenLineText.text = "The last line written was: " + "\n\r" + (currentLine + 1) + ": " +
			inputFieldText.text + " (" + playerName.text + ")";
		//Update the text displaying the last line a player wrote
		FileIOUtility.WriteStringToFile (LAST_LINE_NAME, currentLine + ": " + inputFieldText.text, false);
		//Save the line you just wrote to the Last Line file, so it'll be displayed when the story is next booted up
		SelectRandomLine ();
		SaveStory ();
//		inputFieldText.text = "";
	}

	void SaveStory(){
		//Save the entire story to a text file
		Debug.Log ("Saving story. First line is: " + storyList [0]);
//		FileIOUtility.WriteStringToFile (FILE_NAME, storyList[0], false);
		StreamWriter sr1 = new StreamWriter (FILE_NAME);
		for (int i = 0; i < 40; i++) {
			sr1.WriteLine (storyList [i]);
		}
		sr1.Close ();
	}

	void UpdateStoryPercentage(){

	}

}
