using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Physics : Weapon_Main {

	[Header("Variables del Arma de Fisica")]
	public float force;
	public GameObject bulletPrefab;
	public Animator anim;
	private GameObject lastBullet;

	// Use this for initialization
	void Start () {
		if (spawnPoint == null)
		{
			spawnPoint = transform;
		}
	}

	public override void Sheathe()
	{
		anim.SetBool ("Load", false);
	}

	public override void UnSheathe()
	{
		anim.SetBool ("Load", true);
	}

	public override void Reload()
	{
		anim.SetTrigger("Reload");
	}

	public override void OnShoot()
	{
		Shoot();
	}

	public override void ExecuteShoot()
	{
		base.ExecuteShoot ();
		anim.SetTrigger ("HeavyShot");
		lastBullet = GameObject.Instantiate (bulletPrefab, spawnPoint.position, spawnPoint.rotation);
		lastBullet.GetComponent<Rigidbody> ().AddForce (-spawnPoint.up * force);
	}
}
