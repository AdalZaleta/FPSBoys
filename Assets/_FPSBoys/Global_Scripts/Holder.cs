using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPSBoys
{
	public class Holder : MonoBehaviour {

		void Start () {
			Invoke ("Salir", 1.5f);
		}

		void Salir()
		{
			Debug.Log ("Entre");
			Manager_Static.scenManager.LoadScene (0);
		}
	}
}