using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Melee : Weapon_Main {

	[Header("Variables del Arma Melee")]
	public Animator anim;
	public GameObject handle;
	public GameObject prefSword;
	public GameObject model;
	public float speed;

	void OnTriggerEnter(Collider _col)
	{
		Debug.Log ("Slashed " + _col);
		if (_col.gameObject.CompareTag("Enemy"))
		{
			_col.gameObject.SendMessage ("ReceiveDmg", 1, SendMessageOptions.DontRequireReceiver);
		}
	}

	public override void Sheathe()
	{
		anim.SetBool ("Sheathe", false);
	}

	public override void UnSheathe()
	{
		anim.SetBool ("Sheathe", true);
	}

	public override void OnThrowDown()
	{
		Throw ();
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

	public override void ExecuteThrow()
	{
		base.ExecuteThrow ();
		anim.SetTrigger ("Throw");
		StartCoroutine (thrown ());
	}

	IEnumerator thrown()
	{
		yield return new WaitForSeconds (0.40f);
		model.GetComponent<MeshRenderer> ().enabled = false;
		GameObject go = Instantiate (prefSword, handle.transform.position, handle.transform.rotation);
		go.GetComponent<Rigidbody> ().AddForce (handle.transform.forward * speed);
		//anim.SetBool ("Sheathe", false);
		yield return new WaitForSeconds (0.25f);
		model.GetComponent<MeshRenderer> ().enabled = true;
		anim.SetBool ("Sheathe", true);
	}
}
