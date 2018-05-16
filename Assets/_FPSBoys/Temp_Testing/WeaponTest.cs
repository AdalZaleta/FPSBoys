﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTest : Shooter_test {

	// Class Raycaster

	[Header("Variables del Arma Raycast")]
	public float force;
	public Animator anim;
	private RaycastHit hitInfo;
	LineRenderer line;
	void Start(){
		if (spawnPoint == null)
		{
			spawnPoint = transform;
		}
		line = gameObject.AddComponent<LineRenderer> ();
		line = gameObject.GetComponent<LineRenderer> ();
		line.enabled = false;
	}

	public override void OnShoot()
	{
		Shoot();
	}

	public override void ExecuteShoot()
	{
		base.ExecuteShoot ();
		anim.SetTrigger ("LightShot");
		if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hitInfo))
		{
			if (hitInfo.collider.gameObject.GetComponent<Rigidbody>())
			{
				hitInfo.collider.gameObject.GetComponent<Rigidbody> ().AddForce (spawnPoint.forward * force);
			}
			hitInfo.collider.gameObject.SendMessage ("GotDamage", SendMessageOptions.DontRequireReceiver);
			Debug.DrawLine (spawnPoint.position, hitInfo.point, Color.red);
			StartCoroutine (DrawLine ());
		}
		else
		{
			Debug.DrawRay (spawnPoint.position, spawnPoint.forward * 5, Color.green);
		}
	}

	IEnumerator DrawLine()
	{
		line.positionCount = 2;
		line.widthMultiplier = 0.01f;
		line.SetPosition (0, spawnPoint.transform.position);
		line.SetPosition (1, hitInfo.point);
		line.startColor = Color.green;
		line.endColor = Color.green;
		line.enabled = true;
		yield return new WaitForSeconds (0.02f);
		line.enabled = false;
	}
}
