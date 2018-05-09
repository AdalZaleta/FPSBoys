using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cycle : MonoBehaviour {

	public float vel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.right * vel, Space.Self);
	}
}
