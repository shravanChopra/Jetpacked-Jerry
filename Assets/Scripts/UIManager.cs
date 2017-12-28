using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	// Following singleton pattern
	public static UIManager instance = null;

	// To manage player stats
	private int _playerScore = 0;
	[SerializeField] private Text _scoreText;
	[SerializeField] private GameObject[] _gameOverButtons;
	
	// To track every 10 coins collected
	private int _nextTen = 0;

	// getter for player score
	public int playerScore 
	{
		get { return _playerScore; }
	}

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

	void Start()
	{
		foreach (GameObject button in _gameOverButtons) 
		{
			button.SetActive(false);
		}
	}

	public void UpdateScore()
	{
		++_playerScore;
		++_nextTen;
		_scoreText.text = "" + _playerScore;

		// increase BG speed for every 10 coins collected
		if (_nextTen == 10)
		{
			_nextTen = 0;
			MoveBG.IncreaseBGSpeed();
		}
	}

	public void ShowButtons()
	{
		foreach (GameObject button in _gameOverButtons) 
		{
			button.SetActive(true);
		}
	}
}
