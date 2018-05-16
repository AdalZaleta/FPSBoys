using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTest : Shooter_test {

	[Header("Variables del Arma Melee")]
	public Animator anim;

	// Use this for initialization
	void Start () {
		
	}

	public override void Sheathe()
	{
		anim.SetBool ("Sheathe", false);
	}

	public override void UnSheathe()
	{
		anim.SetBool ("Sheathe", true);
	}

	public override void OnShoot()
	{
		Shoot ();
	}

	public override void ExecuteShoot()
	{
		base.ExecuteShoot ();
		anim.SetTrigger ("Slash");
	}
}
