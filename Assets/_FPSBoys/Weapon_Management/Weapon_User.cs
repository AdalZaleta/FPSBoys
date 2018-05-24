using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPSBoys
{
	public class Weapon_User : MonoBehaviour {

		public Weapon_Main[] myWeapons;
		public int currentWeapon;

		void OnEnable ()
		{
			//Manager_Static.inputManager.ShootDownHandler += UserShootDown;
			Manager_Static.inputManager.ShootHandler += UserShoot;
			Manager_Static.inputManager.ThrowHandler += UserThrow;
			Manager_Static.inputManager.SwitchWeaponHandler += UserChangeWeapon;
			//Debug.Log ("Subscribe to Input");
		}

		void OnDisable ()
		{
			//Manager_Static.inputManager.ShootDownHandler -= UserShootDown;
			Manager_Static.inputManager.ShootHandler -= UserShoot;
			Manager_Static.inputManager.ThrowHandler -= UserThrow;
			Manager_Static.inputManager.SwitchWeaponHandler -= UserChangeWeapon;
		}

		void OnDestroy ()
		{
			//Manager_Static.inputManager.ShootDownHandler -= UserShootDown;
			Manager_Static.inputManager.ShootHandler -= UserShoot;
			Manager_Static.inputManager.ThrowHandler -= UserThrow;
			Manager_Static.inputManager.SwitchWeaponHandler -= UserChangeWeapon;
		}

		// Update is called once per frame
		void Update () {
			// Mouse Testing Controls
			if (Input.GetMouseButtonDown(0))
			{
				myWeapons [currentWeapon].OnShootDown ();
			}
			if (Input.GetMouseButton(0)) 
			{
				myWeapons [currentWeapon].OnShoot ();
			}
			if (Input.GetMouseButtonDown(1))
			{
				myWeapons [currentWeapon].OnThrowDown ();
			}
			if (Input.GetMouseButtonUp(0))
			{
				myWeapons [currentWeapon].OnShootUp ();
			}
			if (Input.GetKey(KeyCode.R))
			{
				myWeapons [currentWeapon].Reload ();
			}
			if (Input.GetKeyDown(KeyCode.Q))
			{
				PreviousWeapon ();
			}
			if (Input.GetKeyDown(KeyCode.E))
			{
				NextWeapon ();
			}
		}

		public void UserShootDown(int _i)
		{
			myWeapons [currentWeapon].OnShootDown ();
		}

		public void UserShoot(int _i)
		{
			myWeapons [currentWeapon].OnShoot ();
		}

		public void UserShootUp()
		{
			myWeapons [currentWeapon].OnShootUp ();
		}

		public void UserReload()
		{
			myWeapons [currentWeapon].Reload ();
		}

		public void UserThrow(int _i)
		{
			myWeapons [currentWeapon].Throw ();
		}

		public void UserChangeWeapon(int i)
		{
			if (i == -1)
				PreviousWeapon ();
			if (i == 1)
				NextWeapon ();
		}

		void NextWeapon()
		{
			myWeapons [currentWeapon].Sheathe ();
			currentWeapon++;
			if (currentWeapon >= myWeapons.Length)
				currentWeapon = 0;
			myWeapons [currentWeapon].UnSheathe ();
		}

		void PreviousWeapon()
		{
			myWeapons [currentWeapon].Sheathe ();
			currentWeapon--;
			if (currentWeapon < 0)
				currentWeapon = myWeapons.Length - 1;
			myWeapons [currentWeapon].UnSheathe ();
		}
	}
}