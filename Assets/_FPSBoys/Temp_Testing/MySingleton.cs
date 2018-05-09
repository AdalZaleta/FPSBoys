using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton : MonoBehaviour {

	private static MySingleton m_instance;

	public static MySingleton Instance
	{
		get
		{
			if (m_instance == null)
			{
				GameObject go = new GameObject ("My Singleton");
				go.AddComponent<MySingleton> ();

				DontDestroyOnLoad (go);
			}
			return m_instance;
		}
	}

	void Awake()
	{
		if (m_instance)
		{
			Destroy (gameObject);
		}
		else
		{
			m_instance = this;
		}
	}

	// Delegate Logic //

	public void Initialize()
	{
		
	}

	public delegate void IntTemplate(int newInt);

	public static IntTemplate AddScoreHandler;
	public static IntTemplate DamagePlayerHandler;

	public void Addscore(int newScore)
	{
		AddScoreHandler (newScore);
	}

	public void DamagePlayer(int damageValue)
	{
		DamagePlayerHandler (damageValue);
	}
}
