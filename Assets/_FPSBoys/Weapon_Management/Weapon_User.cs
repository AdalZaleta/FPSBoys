using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_User : MonoBehaviour {

	public Weapon_Main[] myWeapons;
	public int currentWeapon;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			myWeapons [currentWeapon].OnShootDown ();
		}
		if (Input.GetMouseButton(0))
		{
			myWeapons [currentWeapon].OnShoot ();
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
