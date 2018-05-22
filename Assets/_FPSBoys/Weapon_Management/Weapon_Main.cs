using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Main : MonoBehaviour {

	// Class Weapon

	[Header("Variables de todas las armas")]
	public Transform spawnPoint;
	public float firerate = 0.1f;
	float throwrate = 2.0f;
	internal float lastShootTime;
	internal float lastThrowTime;

	public virtual void OnShootDown()
	{
		
	}

	public virtual void OnThrowDown()
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

	public virtual void Throw()
	{
		if (Time.time > lastThrowTime + throwrate)
		{
			ExecuteThrow ();
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

	public virtual void ExecuteThrow()
	{
		lastThrowTime = Time.time;
	}
}
