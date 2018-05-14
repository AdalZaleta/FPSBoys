using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTest : Shooter_test {

	// Class Raycaster

	[Header("Variables del Arma Raycast")]
	public float force;
	private RaycastHit hitInfo;

	void Start(){
		if (spawnPoint == null)
		{
			spawnPoint = transform;
		}
	}

	public override void OnShoot()
	{
		Shoot();
	}

	public override void ExecuteShoot()
	{
		base.ExecuteShoot ();
		if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hitInfo))
		{
			if (hitInfo.collider.gameObject.GetComponent<Rigidbody>())
			{
				hitInfo.collider.gameObject.GetComponent<Rigidbody> ().AddForce (spawnPoint.forward * force);
			}
			hitInfo.collider.gameObject.SendMessage ("GotDamage", SendMessageOptions.DontRequireReceiver);
			Debug.DrawLine (spawnPoint.position, hitInfo.point, Color.red);
		}
		else
		{
			Debug.DrawRay (spawnPoint.position, spawnPoint.forward * 5, Color.green);
		}
	}
}
