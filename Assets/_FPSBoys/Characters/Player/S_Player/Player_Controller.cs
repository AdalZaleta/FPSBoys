using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPSBoys
{
	public class Player_Controller : MonoBehaviour {

		public GameObject controller;

		public void aim (bool _itis)
		{
			Debug.Log ("entre");
			if (_itis) {
				controller.GetComponent<Camera> ().fieldOfView = Mathf.Lerp (60, 30, 0.75f);
			}
		}
	}
}
