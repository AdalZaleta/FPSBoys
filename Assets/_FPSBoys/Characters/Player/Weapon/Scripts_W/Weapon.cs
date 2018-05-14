using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPSBoys
{
	public class Weapon : MonoBehaviour {

		public void Shoot()
		{
			MySingleton.DamagePlayerHandler (10);
		}
	}
}
