using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanWeHitFiftyLikes : MonoBehaviour {

	public UnityEngine.UI.Text scoreText;

	protected void Start()
	{
		MySingleton.Instance.Initialize ();
	}

	// Subscribe to Singleton Event
	void OnEnable()
	{
		MySingleton.AddScoreHandler += UpdateScoreText;
	}

	void OnDisable()
	{
		MySingleton.AddScoreHandler -= UpdateScoreText;
	}

	void OnDestroy()
	{
		MySingleton.AddScoreHandler -= UpdateScoreText;
	}

	// This method has to meet the delegate's template
	public void UpdateScoreText(int newScore)
	{
		scoreText.text = newScore.ToString ();
	}
}
