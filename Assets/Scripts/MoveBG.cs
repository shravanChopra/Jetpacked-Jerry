using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour {

	// BG movement speed
	[SerializeField] private static float _moveSpeed = 3.0f;

	// reference to UI manager
	private UIManager _uiManager;

	void Start()
	{
		_uiManager = UIManager.instance;
	}

	// Update is called once per frame
	void Update () 
	{
		if (!GameManager.instance.isGameOver)
		{
			// move to the left
			transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
		}
	}

	// Increase BG speed
	public static void IncreaseBGSpeed()
	{
		_moveSpeed += 0.5f;
	}

	public static void ResetBGSpeed()
	{
		_moveSpeed = 3.0f;
	}
}
