using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterTest : MonoBehaviour {

	// Class Shooter

	public Shooter_test[] myWeapons;
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
		if (Input.GetKey(KeyCode.F))
		{
			myWeapons [currentWeapon].OnShoot ();
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
		currentWeapon++;
		if (currentWeapon >= myWeapons.Length)
			currentWeapon = 0;
	}

	void PreviousWeapon()
	{
		currentWeapon--;
		if (currentWeapon < 0)
			currentWeapon = myWeapons.Length - 1;
	}
}
