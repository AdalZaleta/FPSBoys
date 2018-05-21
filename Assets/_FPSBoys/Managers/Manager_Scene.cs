using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPSBoys
{
	public class Manager_Scene : MonoBehaviour {

		void Awake()
		{
			Manager_Static.scenManager = this;
		}
	}


}
