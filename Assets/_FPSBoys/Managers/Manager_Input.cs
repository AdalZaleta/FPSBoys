using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

namespace FPSBoys
{	
	public class Manager_Input : MonoBehaviour {

		void Awake()
		{
			//ASIGNO AL MANAGER STATIC CUAL VA A SER EL INPUT MANGER
			Manager_Static.inputManager = this;
		}

		void Update()
		{
			//CODIGO DE LOS INPUTS DEPENDIEDO DEL ESTADO DEL JUEGO

			//LOS INPUTS DE CUANDO ESTES EN EL MENU PRINCIPAL
			if (Manager_Static.appManager.currentState == AppState.main_menu) {
			}

			//LOS INPUTS DE CUANDO ESTES EN GAMEPLAY
			if (Manager_Static.appManager.currentState == AppState.gameplay) {
				if (Input.GetAxisRaw ("Left_Trigger") <= -0.5f) {
					//Inteto manda a llamr a un escript de player controler
					SendMessage ("aim", true, SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetAxisRaw ("Right_Trigger") <= -0.7f) {
					//Debug.Log ("El valor del gatillo derecho es: " + Input.GetAxisRaw ("Right_Trigger"));
					GamePad.SetVibration (PlayerIndex.One, 0.75f, 0.75f);
					ShootHandler (1);
					//Debug.Log ("Se llamo al Handler");
					//GamePad.SetVibration (1, 0.5, 0.5);
				}
				if (Input.GetAxisRaw ("Right_Trigger") > -0.5f) {
					GamePad.SetVibration (PlayerIndex.One, 0f, 0f);
					//GamePad.SetVibration (1, 0.5, 0.5);
				}

			}

			//LOS INPUTS DE CUANDO ESTES EN GAME_MENU
			if (Manager_Static.appManager.currentState == AppState.pause_menu) {
			}

			//LOS INPUTS DE CUANDO ESTES EN END_GAME
			if (Manager_Static.appManager.currentState == AppState.end_game) {
			}
		}

		public delegate void InputTemplate (int _id);

		public InputTemplate ShootHandler;
		public InputTemplate ShootDownHandler;
		public InputTemplate ShootUpHandler;
	}
}
