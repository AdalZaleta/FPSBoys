using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPSBoys
{
	public class Win_Conditions : MonoBehaviour {

		public float timeGoal;
		public Text timer;
		
		// Update is called once per frame
		void Update () {
			if (timeGoal > 0)
				timeGoal -= Time.deltaTime;

			timer.text = "Time: " + (int)timeGoal + " seg";


			if (timeGoal < 0)
				Debug.Log ("Has ganado");
		}
	}
}