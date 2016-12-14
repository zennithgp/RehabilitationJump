using UnityEngine;
using System.Collections;
using System.IO;
using SimpleJSON;

//This is a utility script, so we've removed MonoBehavior
//There's no Start or Update, since we're not attaching this to a game object
public class FileIOUtility {

	/*We want to read text files
	 * Write to text files
	 * Save JSONs
	 * Read JSONs
	 */

	/// <summary>
	/// Writes the string to file.
	/// </summary>
	/// <param name="fileName">The location and name of the file.</param>
	/// <param name="content">What you're writing to the .txt file.</param>
	/// <param name="append">If set to <c>true</c>, append. Otherwise, rewrite entire file.</param>
	public static void WriteStringToFile(string fileName, string content, bool append){
		StreamWriter sw = new StreamWriter (fileName, append); //open a stream to the file
		sw.WriteLine (content); //write the content, either appended to the end or rewriting it
		sw.Close (); //remember to always close your streams
	}

	/// <summary>
	/// Reads the string from a file.
	/// </summary>
	/// <returns>The string from the file.</returns>
	/// <param name="fileName">The location and name of the file.</param>
	public static string ReadStringFromFile(string fileName){
		//check to see if the file exists
		if(!File.Exists(fileName)){
			Debug.Log ("WARNING: You tried to read from file \"" + fileName + "\", but it doesn't exist. Returning anull string.");
			return null;
		}			
		StreamReader sr = new StreamReader (fileName);
		string output = sr.ReadToEnd ();
		sr.Close ();
		return output;
	}

	public static void WriteJsonToFile(string fileName, JSONClass json){
		//to write a JSON to a file, convert it to a string, then use our existing function
		string output = json.ToString ();
		WriteStringToFile (fileName, output, false);
	}

	public static JSONNode ReadJsonFromFile (string fileName){
		//check if the file is a JSON file
		if (Path.GetExtension (fileName) != ".json") {
			Debug.Log ("WARNING: You tried to read a JSON from file \"" + fileName + "\", but it's not a JSON. Returning null.");
			return null;
		}

		string outputString = ReadStringFromFile (fileName);
		JSONNode outputJSON = JSONClass.Parse (outputString);
		return outputJSON;
	}
}
