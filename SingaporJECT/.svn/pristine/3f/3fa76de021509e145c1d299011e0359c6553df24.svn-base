using UnityEngine;
using System.Collections;
using SimpleJSON;

public class W6GameManager : MonoBehaviour {
	public string fileName;
	const string PATH = "Assets/";

	//STUFF LEARNED:
	//-ENCAPSULATION (only work on the stuff you're working on right now. You have a Util script to make static functions)


	// Use this for initialization
	void Start () {
	
		//other static functions: Debug.Log, GameObject.Find, Mathf.ANYTHING, Vector3.Distance

		//write "Hello World" to a file.
//		FileIOUtility.WriteStringToFile (PATH + fileName, "Hello World");

//		string output = FileIOUtility.ReadStringFromFile (PATH + fileName);
//		Debug.Log (output);

		JSONClass json = new JSONClass ();

		json["name"] = "Matt"; //this is adding something to the JSON file
		json["height"].AsInt = 6;
		json["student"].AsBool = false;

		string strJson = json.ToString ();

		JSONNode converted = JSONClass.Parse (strJson);

//		Debug.Log("json: " + strJson);
//		Debug.Log ("Name: " + json ["name"]);
//		Debug.Log ("Converted" + converted.ToString());

		FileIOUtility.WriteJsonToFile (PATH + "temp.json", json);
		Debug.Log (FileIOUtility.ReadJsonFromFile (PATH + "temp.json").ToString ());
//		JSONNode tempJson = FileIOUtility.ReadJsonFromFile (PATH + fileName);
//		Debug.Log ("Read JSON from file: " + tempJson.ToString());

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
