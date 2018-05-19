using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPSBoys{
	public class GodsHand : MonoBehaviour {

		public GameObject enemy;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				enemy.GetComponent<EvilBoi_Behaviour> ().ReceiveDmg (1);
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				enemy.GetComponent<EvilBoi_Behaviour> ().ReceiveDmg (2);
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				enemy.GetComponent<EvilBoi_Behaviour> ().ReceiveDmg (3);
			}
		}
	}
}
