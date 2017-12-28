using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private bool _isGameOver = false;
	public bool isGameOver 
	{
		get { return _isGameOver; }
		set { _isGameOver = value; }
	}

	// make this a singleton
	public static GameManager instance = null;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Update()
	{
		if (_isGameOver)
		{
			UIManager.instance.ShowButtons();
			MoveBG.ResetBGSpeed();
		}
	}

	public void PlayAgain()
	{
		SceneManager.LoadScene(1);
	}

	public void ShowMainMenu()
	{
		SceneManager.LoadScene(0);
	}
}
