using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerTest : Shooter_test {

	[Header("Variables del Arma de Fisica")]
	public float force;
	public GameObject bulletPrefab;
	private GameObject lastBullet;

	// Use this for initialization
	void Start () {
		if (spawnPoint == null)
		{
			spawnPoint = transform;
		}
	}

	public override void OnShootDown()
	{
		Shoot();
	}

	public override void ExecuteShoot()
	{
		base.ExecuteShoot ();
		lastBullet = GameObject.Instantiate (bulletPrefab, spawnPoint.position, spawnPoint.rotation);
		lastBullet.GetComponent<Rigidbody> ().AddForce (spawnPoint.forward * force);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
