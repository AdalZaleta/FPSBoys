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
				Manager_Static.uiManager.ShowTime ();
				if (Input.GetAxisRaw ("Left_Trigger") <= -0.5f) {
					//Inteto manda a llamr a un escript de player controler
					SendMessage ("aim", true, SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetAxisRaw ("Right_Trigger") <= -0.7f) {
					//Debug.Log ("El valor del gatillo derecho es: " + Input.GetAxisRaw ("Right_Trigger"));
					GamePad.SetVibration (PlayerIndex.One, 0.25f, 0.25f);
					ShootHandler (1);
					//Debug.Log ("Se llamo al Handler");
					//GamePad.SetVibration (1, 0.5, 0.5);
				}
				if (Input.GetAxisRaw ("Right_Trigger") > -0.5f) {
					GamePad.SetVibration (PlayerIndex.One, 0f, 0f);
					//GamePad.SetVibration (1, 0.5, 0.5);
				}
				if (Input.GetButtonDown("Fire3"))
				{
					ThrowHandler (1);
					Debug.Log ("Pressed X Button");
				}
				if (Input.GetButtonDown("R_Bumper"))
				{
					SwitchWeaponHandler (1);
					Debug.Log("Pressed Right Bumper");
				}
				if (Input.GetButtonDown("L_Bumper"))
				{
					SwitchWeaponHandler(-1);
					Debug.Log("Pressed Left Bumper");
				}
				if (Input.GetKeyDown (KeyCode.JoystickButton7)) 
				{
					Manager_Static.appManager.currentState = AppState.pause_menu;
				}
			}

			//LOS INPUTS DE CUANDO ESTES EN GAME_MENU
			if (Manager_Static.appManager.currentState == AppState.pause_menu) {
				Manager_Static.uiManager.PauseTime ();
				if (Input.GetKeyDown (KeyCode.JoystickButton6)) 
				{
					Manager_Static.appManager.currentState = AppState.gameplay;
				}
			}

			//LOS INPUTS DE CUANDO ESTES EN END_GAME
			if (Manager_Static.appManager.currentState == AppState.end_game) {
			}
		}

		public delegate void InputTemplate (int _id);

		public InputTemplate ShootHandler;
		public InputTemplate ShootDownHandler;
		public InputTemplate ShootUpHandler;
		public InputTemplate ThrowHandler;
		public InputTemplate SwitchWeaponHandler;
	}
}
