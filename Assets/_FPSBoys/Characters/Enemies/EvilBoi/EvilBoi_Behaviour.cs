using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FPSBoys{
	public class EvilBoi_Behaviour : MonoBehaviour {

		public int HP;
		public float Dmg;
		public float AtkCooldown;
		int freezeCount;
		int shockdmg = 1;
		bool canDmg = true;
		bool inRange = false;
		public GameObject model;
		public Animator anim;
		public NavMeshAgent agent;
		GameObject player;
		float lasthit;

		void Start()
		{
			player = GameObject.FindGameObjectWithTag ("Player");
			agent.SetDestination (player.transform.position);
		}

		void Update()
		{
			if (agent.enabled == true) 
			{
				if (player)
				{
					agent.SetDestination (player.transform.position);
					if (agent.remainingDistance <= 1)
					{
						inRange = true;
					}
					else
					{
						inRange = false;
					}
					if (inRange)
					{
						if (Time.time > lasthit + AtkCooldown)
						{
							Debug.Log("Attack!");
							Attack ();
							lasthit = Time.time;
						}

					}
				}
				else
				{
					inRange = false;
					agent.SetDestination (gameObject.transform.position);
				}
					
			}
		}

		public void Attack()
		{
			anim.SetTrigger ("attack");
			player.SendMessage ("ReceiveDmg", Dmg, SendMessageOptions.DontRequireReceiver);
		}

		public void ReceiveDmg(int type)
		{
			if (canDmg) 
			{
				switch (type) 
				{
				case 1:
					// Default Bullet Event
					Debug.Log ("Damaged | Common");
					HP -= 10;
					StartCoroutine (blink ());
					CheckHP ();
					break;
				case 2:
					// Ice Bullet Event
					Debug.Log ("Damaged | Freeze");
					HP -= 25;
					freezeCount++;
					StartCoroutine (blink ());
					CheckHP ();
					break;
				case 3:
					// Lightning Bullet Event
					Debug.Log ("Damaged | Lightning");
					HP -= 10;
					StartCoroutine (shock (3));
					StartCoroutine (blink ());
					CheckHP ();
					break;
				default:
					Debug.Log ("Switch entered default");
					break;
				}
			}
		}

		public void CheckHP ()
		{
			if (HP <= 0)
			{
				StartCoroutine (Flop ());
			}
		}

		IEnumerator blink()
		{
			canDmg = false;
			model.GetComponent<MeshRenderer> ().material.color = Color.red;
			yield return new WaitForSeconds (0.05f);
			model.GetComponent<MeshRenderer> ().material.color = Color.white;
			yield return new WaitForSeconds (0.05f);
			model.GetComponent<MeshRenderer> ().material.color = Color.red;
			yield return new WaitForSeconds (0.05f);
			model.GetComponent<MeshRenderer> ().material.color = Color.white;
			canDmg = true;
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

		IEnumerator Flop()
		{
			GetComponent<CapsuleCollider> ().enabled = false;
			agent.enabled = false;
			if (anim.GetBool("in"))
				anim.SetBool ("in", false);
			yield return new WaitForSeconds (0.25f);
			anim.enabled = false;
			model.GetComponent<Rigidbody> ().useGravity = true;
			model.GetComponent<Rigidbody> ().isKinematic = false;
			Destroy (gameObject, 5.0f);
		}
	}
}
