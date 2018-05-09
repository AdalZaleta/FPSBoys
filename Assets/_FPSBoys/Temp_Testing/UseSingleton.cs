using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSingleton : MonoBehaviour {

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			MySingleton.Instance.Addscore (50);
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			MySingleton.Instance.DamagePlayer (10);
		}
	}
}
