using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataStructureExamples : MonoBehaviour {

	public List<string> nameList;
	//this is a LIST. It's a flexible, slower array.
	//this is a GENERIC. Generics have the format blah<blah> - you're telling it to do something <OF THIS TYPE>
	//here, we're making a list OF STRINGS

	public Dictionary<KeyCode, string> characterDictionary;
	//this is a DICTIONARY.
	//I'm specifying that a generic type of key matches to a generic type of value
	//we can make a relationship between two very different things
	//Dictionaries are not supported by the Unity editor.
	//Dictionaries DON'T have an order. There's no first slot, just a relation between things.

	public Queue<string> inLine;
	//this is a QUEUE
	//it's First In, First Out (FIFO)
	//there's nothing you can do with it that you can't do with a list
	//unlike a list, it is very structured. It exists to support FIFO operations

	public Stack<string> cards;
	//this is a STACK
	//it's Last In, First Out (LIFO)

	// Use this for initialization
	void Start () {
	

	//LISTS!

		//names = new List<string> ();
		//if you don't declare it in the inspector, you need to declare it in code

		//lists are slower than arrays
		Debug.Log ("Length of names: " + nameList.Count);

		nameList.Add ("Matt"); //appends to the end of the list
		nameList.Insert (1, "Ewing"); //inserts something in the 2nd slot and bumps everything back
		nameList.Remove ("Matt"); //remove the first instance of "Matt"
		nameList.RemoveAt (0); //remove the 1st thing in the list

		//hey, it's a forEach loop!
		foreach (string name in nameList) {
			Debug.Log ("name: " + name);
			//Count is the list equivalent to array.length
			//Count is a PROPERTY!
		}

		//clear completely empties the list
		nameList.Clear ();


	//DICTIONARY

		//we need to declare our dictionary
		characterDictionary = new Dictionary<KeyCode, string>();

		characterDictionary.Add (KeyCode.A, "Alice");
		characterDictionary.Add (KeyCode.B, "Bomberman");
		characterDictionary.Add (KeyCode.C, "Clank");
		characterDictionary.Add (KeyCode.D, "Diddy Kong");

//		characterDictionary.Clear ();
//		characterDictionary.ContainsKey(KeyCode.A);
//		characterDictionary.ContainsValue("Mike");


	//QUEUE

		inLine = new Queue<string> ();

		inLine.Enqueue ("Matt");
		inLine.Enqueue ("Missy");
		inLine.Enqueue ("Eli");

		Debug.Log("first in line: " + inLine.Peek()); //peek LOOKS at who is first in linfe
		Debug.Log ("First in line " + inLine.Dequeue()); //dequeue POPS them off the line and returns them
		Debug.Log ("First in line " + inLine.Dequeue()); //this will return a different person/value


	//STACK

		cards = new Stack<string> ();
		cards.Push ("Ace");
		cards.Push ("King");
		cards.Push ("Queen");
		cards.Push ("Jack");
//		cards.Peek (); //look at the top card
//		cards.Pop (); //take the top card off of the stack

		Debug.Log ("card: " + cards.Pop ());

	}
	
	// Update is called once per frame
	void Update () {
	
		foreach (KeyCode button in characterDictionary.Keys) {
			if (Input.GetKeyDown (button)) {
				Debug.Log ("Character Name: " + characterDictionary[button]);
			}
		}

	}
}
