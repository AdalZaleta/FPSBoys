using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPSBoys
{
	public class Manager_UI : MonoBehaviour {

		public GameObject minimenu;
		public float TimeScale;

		void Awake()
		{
			Manager_Static.uiManager = this;
			TimeScale = Time.timeScale;
		}

		public void PauseTime()
		{
			Time.timeScale = 0.0f;
			minimenu.SetActive (true);
		}

		public void ShowTime()
		{
			Time.timeScale = TimeScale;
			minimenu.SetActive (false);
		}
	}
}
