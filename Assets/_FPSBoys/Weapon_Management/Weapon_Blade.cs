using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Blade : MonoBehaviour {

	void OnTriggerEnter(Collider _col)
	{
		Debug.Log ("Slashed " + _col);
		if (_col.gameObject.CompareTag("Enemy"))
		{
			_col.gameObject.SendMessage ("ReceiveDmg", 1, SendMessageOptions.DontRequireReceiver);
		}
	}
}
