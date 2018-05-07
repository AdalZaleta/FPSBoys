using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPSBoys{
	public class EvilBoi_Behaviour : MonoBehaviour {

		public int HP;
		int freezeCount;
		int shockdmg = 1;
		public GameObject model;

		public void RecieveDmg(int type, int dmg)
		{
			switch (type)
			{
			case 1:
				// Default Bullet Event
				HP -= dmg;
				StartCoroutine (blink ());
				break;
			case 2:
				// Ice Bullet Event
				HP -= dmg;
				freezeCount++;
				StartCoroutine (blink ());
				break;
			case 3:
				// Lightning Bullet Event
				HP -= dmg;
				StartCoroutine (shock (3));
				StartCoroutine (blink ());
				break;
			default:
				Debug.Log ("Switch entered default");
				break;
			}
		}

		IEnumerator blink()
		{
			model.GetComponent<SkinnedMeshRenderer> ().material.color = Color.red;
			yield return new WaitForSeconds (0.2f);
			model.GetComponent<SkinnedMeshRenderer> ().material.color = Color.white;
			yield return new WaitForSeconds (0.2f);
			model.GetComponent<SkinnedMeshRenderer> ().material.color = Color.red;
			yield return new WaitForSeconds (0.2f);
			model.GetComponent<SkinnedMeshRenderer> ().material.color = Color.white;
		}

		IEnumerator shock(int time)
		{
			yield return new WaitForSeconds (1.0f);
			HP -= shockdmg;
			if (time > 0)
			{
				time--;
				StartCoroutine (shock (time));
			}
		}
	}
}
