using UnityEngine;
using System.Collections;

public class BasicGun : MonoBehaviour {

	GameObject bulletPool;

	// Use this for initialization
	void Start () {
		bulletPool = new GameObject ("Bullet Pool");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			Fire ();
		}
	}

	//VIRTUAL means use this function in all of my subclasses unless they override it. In that case, use their function.
	public virtual GameObject Fire(){
		GameObject bullet = Instantiate(Resources.Load("Bullet")) as GameObject;
		bullet.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 5, 0);
		bullet.transform.position = transform.position;
		bullet.transform.parent = bulletPool.transform;
		return bullet;
	}

}
