using UnityEngine;
using System.Collections;

public class SpawnRandomBullet : MonoBehaviour {


	public const string PATH = "Assets/Resources/";
	private const string RED_BULLET_PATH = "RedBullet";
	private const string BLUE_BULLET_PATH = "BlueBullet";
	private const string SOLID_BULLET = "BlockBullet";
	GameObject enemyContainer;
	public Vector3 bulletSpeed = new Vector3 (0, -10, 0);


	// Use this for initialization
	void Start () {

		enemyContainer = new GameObject ("Enemy Container");

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.C)) {
			SpawnRandomEnemy ();
		}

	}

	void SpawnRandomEnemy(){
		int randomSelector = Random.Range (1, 3);
		Debug.Log ("Random number chosen! The number is: " + randomSelector);
//		GameObject bullet = new GameObject();
		if (randomSelector == 1) {
			GameObject bullet = Instantiate (Resources.Load (RED_BULLET_PATH) as GameObject);
			bullet.transform.position = transform.position;
			bullet.transform.parent = enemyContainer.transform;
			Rigidbody bulletRigidBody = bullet.GetComponent<Rigidbody> ();
			bulletRigidBody.AddForce (bulletSpeed);
		}
		if (randomSelector == 2) {
			GameObject bullet = Instantiate (Resources.Load (BLUE_BULLET_PATH) as GameObject);
			bullet.transform.position = transform.position;
			bullet.transform.parent = enemyContainer.transform;
			Rigidbody bulletRigidBody = bullet.GetComponent<Rigidbody> ();
			bulletRigidBody.AddForce (bulletSpeed);
		}
		if (randomSelector == 3) {
			GameObject bullet = Instantiate (Resources.Load (SOLID_BULLET) as GameObject);
			bullet.transform.position = transform.position;
			bullet.transform.parent = enemyContainer.transform;
			Rigidbody bulletRigidBody = bullet.GetComponent<Rigidbody> ();
			bulletRigidBody.AddForce (bulletSpeed);
		}

//		bullet.transform.position = transform.position;
//		bullet.transform.parent = enemyContainer.transform;
//		Rigidbody bulletRigidBody = bullet.GetComponent<Rigidbody> ();
//		bulletRigidBody.AddForce (bulletSpeed);



	}
}
