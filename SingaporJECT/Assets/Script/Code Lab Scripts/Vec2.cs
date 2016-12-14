using UnityEngine;
using System.Collections;

public class Vec2 {

	//MonoBeaviour WAS the superclass
	//It enables us to attach it to GameObjects. (It also comes with lots of other cool functionality.)
	//We want to be able to attach a transform to a game object, not a Vector2.
	//With everything gone, we have a totally empty class.


	//A Vec2 should have an x and a y.


	//FIELDS: variables in a class
	public float x = 0;
	public float y = 0;


	//by default, most classes have base classes, even if we don't give them one.
	//all objects extend from Object, a class everything extends from
	//because of that, we inherit a Default Constructor, which lets us make another one of these thingds.
	//a Constructor is a special kind of function that can live inside of an object
	//a Constructor allows you to pass information into an object



	//the NEW keyword happens whenever you're assigning the variables

	//with Vector3, we need to say NEW Vector3.
	//


	//default constructor
	public Vec2(){
		Debug.Log ("Called Vec2 default constructor.");
	}

	//we can have multiple constructors, as long as they take different parameters
	public Vec2(float x, float y){
		this.x = x;
		this.y = y;

		//THIS means the object I am currently in.
		//If we don't specify, we find the deepest scope thing we can find (in this case, the function's parameters)
	}

	public Vec2(bool isRand){
		if (isRand) {
			x = Random.Range (0, 1000);
			y = Random.Range (0, 1000);
		}
	}
}
