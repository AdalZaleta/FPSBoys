using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour {

	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision _col)
	{
		_col.gameObject.SendMessage ("GotDamage", SendMessageOptions.DontRequireReceiver);
		if (explosionPrefab)
		{
			Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}

	}
}
