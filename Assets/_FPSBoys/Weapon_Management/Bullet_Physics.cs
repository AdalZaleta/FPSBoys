using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Physics : MonoBehaviour {

	public float force;
	public GameObject IcerodPrefab;
	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision _col)
	{
		_col.gameObject.SendMessage ("ReceiveDmg", SendMessageOptions.DontRequireReceiver);
		if (explosionPrefab)
		{
			Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider _col)
	{
		if (_col.gameObject.GetComponent<Rigidbody>())
		{
			_col.gameObject.GetComponent<Rigidbody> ().AddForce (-gameObject.transform.up * force);
		}
		_col.gameObject.SendMessage ("ReceiveDmg", 2, SendMessageOptions.DontRequireReceiver);
		StartCoroutine (Stab (_col.gameObject));
	}

	IEnumerator Stab(GameObject parent)
	{
		yield return new WaitForSeconds (0.0001f);
		GameObject icerod = Instantiate (IcerodPrefab, transform.position, transform.rotation);
		icerod.transform.parent = parent.transform;
		icerod.transform.localScale = new Vector3 (4, 10, 4);
		Destroy (icerod, 2.0f);
		Destroy (gameObject);
	}
}
