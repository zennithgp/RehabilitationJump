using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QueueGunScript : MonoBehaviour {

	//INTENT BEHIND THIS BIZARRE SCRIPT
	/* After having essentially no ideas for what to do with these data structures, I thought about the weird color-queue space shooter from class.
	 * What if you have to enqueue bullets in a 4-size stack to destroy obstacles of the same color as your bullet?
	 * I don't think I'll get all the code working, but it'd be interesting to make this a fully playable game for the final.
	 */


	GameObject bulletPool;
	public Vector3 bulletSpeed = new Vector3 (0, 5, 0);
	public float cooldown = 0.3f;
	float cooldownTimer = 0;

	public Queue<string> bulletQueue;

	// Use this for initialization
	void Start () {
		bulletPool = new GameObject ("Bullet Pool");

		bulletQueue = new Queue<string> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (cooldownTimer > 0) {
			cooldownTimer = cooldownTimer - Time.deltaTime;
		}

		Debug.Log ("Cooldown: " + cooldownTimer);

		if (Input.GetKeyDown (KeyCode.I) && (cooldownTimer <= 0) ) {
//			FireSelectedBullet ("Bullet");
			AddBulletToQueue("Bullet");
			cooldownTimer = cooldown;
		}
		if (Input.GetKeyDown (KeyCode.O) && (cooldownTimer <= 0) ) {
//			FireSelectedBullet ("BlueBullet");
			AddBulletToQueue("BlueBullet");
			cooldownTimer = cooldown;
		}
		if (Input.GetKeyDown (KeyCode.P) && (cooldownTimer <= 0) ) {
//			FireSelectedBullet ("RedBullet");
			AddBulletToQueue("RedBullet");
			cooldownTimer = cooldown;
		}
	}

	void AddBulletToQueue (string bulletName){
		bulletQueue.Enqueue (bulletName);
		if (bulletQueue.Count > 3) {
			FireSelectedBullet (bulletQueue.Dequeue());
		}
//		if (bulletQueue.Peek == "Bullet") {
//			gameObject.renderer.material.color
//		}
	}

	public GameObject FireSelectedBullet(string bulletName){
		GameObject bullet = Instantiate (Resources.Load (bulletName)) as GameObject;
		bullet.GetComponent<Rigidbody> ().velocity = bulletSpeed;
		bullet.transform.position = transform.position;
		bullet.transform.parent = bulletPool.transform;
		return bullet;
	}
}
