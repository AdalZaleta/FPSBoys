using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Explosion : MonoBehaviour {

	public SphereCollider myCollider;

	public float explosionForce;
	public float explosionDuration = 1.0f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, explosionDuration);
	}

	protected void OnTriggerEnter(Collider _col)
	{
		_col.gameObject.SendMessage ("GotDamage", 1, SendMessageOptions.DontRequireReceiver);
		if (_col.gameObject.GetComponent<Rigidbody>())
		{
			_col.gameObject.GetComponent<Rigidbody> ().AddExplosionForce (explosionForce, transform.position, myCollider.radius);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
