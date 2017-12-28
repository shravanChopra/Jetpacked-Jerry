using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	private Player _player;
	private Animator _anim;

	void Start()
	{
		_anim = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && !GameManager.instance.isGameOver)
		{
			_player = other.GetComponent<Player>();
			_player.Die();
			_anim.Play("Laser_Off");
		}
	}
}
