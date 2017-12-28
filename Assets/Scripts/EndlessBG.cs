using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBG : MonoBehaviour {

	// position where new piece needs to be to simulate 'endlessness'
	[SerializeField] private static Vector3 _newPosition = new Vector3(23f, 0f, 0f);

	// to instantiate coins in patterns
	[SerializeField] private GameObject _coinPrefab;
	[SerializeField] private Transform _coinSpawnPoint;
	[SerializeField] private int _maxCoinsInWave = 5;
	private float _xOffset = 1.5f;
	private float _yOffset = 1.5f;

	// to create lasers
	[SerializeField] private Transform[] _laserPrefabs;

	void Start()
	{
		CreateCoinPattern();
	}

	// Update is called once per frame
	void Update ()
	{
		// reappear on other side when you go off screen
		if (transform.position.x < -15f)
		{
			transform.position = _newPosition;
			CreateCoinPattern();
			PositionLasers();
		}	
	}

	private void CreateCoinPattern() 
	{
		Vector3 coinPosition = _coinSpawnPoint.position;

		for (int i = 0; i < _maxCoinsInWave; ++i) 
		{
			GameObject coin = Instantiate(_coinPrefab, coinPosition, Quaternion.identity);
			coin.transform.parent = transform;

			// get new position based on current spawn point
			coinPosition = GetNewRandomPosition(coinPosition);
		}
	}

	private Vector3 GetNewRandomPosition(Vector3 lastCoinPos)
	{
		float newX, newY;

		// randomize the x
		if (Random.Range(0, 2) == 0)
		{
			newX = _xOffset;
		}
		else 
		{
			newX = -_xOffset;
		}

		// determine if the y is increasing or decreasing, based on the spawn pt
		if (_coinSpawnPoint.tag == "Bottom")
		{
			newY = _yOffset;
		}
		else
		{
			newY = -_yOffset;
		}

		return new Vector3(lastCoinPos.x + newX, lastCoinPos.y + newY);
	}

	private void PositionLasers()
	{
		foreach (Transform laser in _laserPrefabs)
		{
			float newY = Random.Range(-1f, 2f);
			laser.position = new Vector3(laser.position.x, newY);
		}
	}
}
