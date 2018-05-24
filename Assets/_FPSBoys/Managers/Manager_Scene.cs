using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPSBoys
{
	public class Manager_Scene : MonoBehaviour {

		public GameObject options;

		void Awake()
		{
			Manager_Static.scenManager = this;
		}

		public void LoadScene(int _scene)
		{
			SceneManager.LoadScene (_scene, LoadSceneMode.Single);
		}

		public void QuitGame()
		{
			Application.Quit ();
		}

		public void LoadGame(int _character)
		{
			options.GetComponent<Play_Options> ().setCurrentCharacter (_character);
			DontDestroyOnLoad (options.GetComponent<Play_Options> ());
			SceneManager.LoadScene ("Main_Testing");
		}
	}
}
