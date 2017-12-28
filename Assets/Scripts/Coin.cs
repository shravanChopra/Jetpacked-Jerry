using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	// reference to Player behaviour script
	private Player _player;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			_player = other.GetComponent<Player>();
			
			if (_player != null)
			{
				_player.CollectCoin();
				Destroy(gameObject);

			}
		}
	}
}
