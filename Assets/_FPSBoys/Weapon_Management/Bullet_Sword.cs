using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Sword : MonoBehaviour {

	public float Tspeed;
	public GameObject model;
	bool Spin = true;

	void Update()
	{
		if (Spin)
			model.transform.Rotate (Vector3.right * Tspeed);
	}
	
	void OnTriggerEnter(Collider _col)
	{
		if (_col.gameObject.CompareTag ("Enemy"))
		{
			_col.gameObject.SendMessage ("ReceiveDmg", 1, SendMessageOptions.DontRequireReceiver);
			Destroy (gameObject, 2.0f);
		}
		else if (_col.gameObject.CompareTag("Scene"))
		{
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			GetComponent<Rigidbody> ().rotation = Quaternion.identity;
			Spin = false;
			Destroy (gameObject, 5.0f);
		}
	}
}
