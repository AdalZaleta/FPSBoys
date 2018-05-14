using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_test : MonoBehaviour {

	// Class Weapon

	[Header("Variables de todas las armas")]
	public Transform spawnPoint;
	public float firerate = 0.1f;
	internal float lastShootTime;

	public virtual void OnShootDown()
	{
		
	}

	public virtual void OnShoot()
	{
		
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

	public virtual void ExecuteShoot()
	{
		lastShootTime = Time.time;
	}
}
