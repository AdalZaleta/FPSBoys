using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPSBoys
{
	public class Play_Options : MonoBehaviour {

		public int actualCharacter;

		public void setCurrentCharacter(int current)
		{
			actualCharacter = current;
		}
	}
}
