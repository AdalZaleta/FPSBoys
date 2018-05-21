using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPSBoys
{
	public class Manager_UI : MonoBehaviour {

		void Awake()
		{
			Manager_Static.uiManager = this;
		}
	}
}
