using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Main : MonoBehaviour {

	// Class Weapon

	[Header("Variables de todas las armas")]
	public Transform spawnPoint;
	public float firerate = 0.1f;
	internal float lastShootTime;

	public virtual void OnShootDown()
	{
		Debug.Log ("ShootDown desde Main");
	}

	public virtual void OnShoot()
	{
		Debug.Log ("OnShoot desde Main");
	}

	public virtual void OnShootUp()
	{

	}

	public virtual void Shoot()
	{
		if (Time.time > lastShootTime + firerate)
		{
			ExecuteShoot ();
		}
	}

	public virtual void Reload()
	{

	}

	public virtual void Sheathe ()
	{

	}

	public virtual void UnSheathe ()
	{

	}

	public virtual void ExecuteShoot()
	{
		lastShootTime = Time.time;
	}
}
