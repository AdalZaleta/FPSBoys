using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPSBoys
{
	public class Manager_App : MonoBehaviour {

		public AppState currentState;
		//En algun momento me tengo que asegurar de que el estado cambie conforme al estado del juego
		void Awake()
		{
			Manager_Static.appManager = this;
		}
	}
}
