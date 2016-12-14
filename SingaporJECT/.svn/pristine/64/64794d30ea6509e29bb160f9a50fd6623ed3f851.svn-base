using UnityEngine;
using System.Collections;

public class TripleShotGun : BasicGun {
	//we've extended BASIC GUN. We still inherit MonoBehaviour because basic gun has it!
	//we still have Start and Update. If we added our own Start and Update, they'd replace the ones we've inherited from BasicGun


	//we want to override this function
	//in C#, we have to tell a function that it can be overwritten
	//so the original function is virtual (it can be overwritten)
	//this overrides it (with override)
	public override GameObject Fire(){
		base.Fire();
		GameObject bullet2 = base.Fire ();
		bullet2.transform.position = new Vector3 (
			transform.position.x + 0.5f,
			transform.position.y,
			transform.position.z);
		GameObject bullet3 = base.Fire ();
		bullet3.transform.position = new Vector3 (
			transform.position.x - 0.5f,
			transform.position.y,
			transform.position.z);
		return bullet2;
	}

}
