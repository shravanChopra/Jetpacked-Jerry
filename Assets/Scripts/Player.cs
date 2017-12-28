using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private bool _isAlive = true;
	private float _upwardForce = 5f;

	// reference to jetpack particle system
	[SerializeField] private ParticleSystem _jetpackTrail;

	// references to components
	private Animator _anim;
	private Rigidbody2D _rigidbody;
	private AudioSource _runningAudio;

	// Use this for initialization
	void Start () 
	{
		// get handles on components
		_anim = GetComponent<Animator>();
		_rigidbody = GetComponent<Rigidbody2D>();
		_runningAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0) && _isAlive)
		{
			Fly();
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ground" && _isAlive)
		{
			_anim.Play("Run");
			_runningAudio.Play();
		}	
	}

	private void Fly()
	{
		_rigidbody.AddForce(Vector2.up * _upwardForce, ForceMode2D.Impulse);
		_anim.Play("Fly");

		// show jetpack trail
		_jetpackTrail.Play();

		// change audio
		_runningAudio.Stop();
		AudioManager.instance.PlayAudio(AudioManager.GameAudioEnum.JetPack);

	}

	public void CollectCoin()
	{
		// update score and play sound
		UIManager.instance.UpdateScore();
		AudioManager.instance.PlayAudio(AudioManager.GameAudioEnum.Coin);
	}

	public void Die()
	{
		_isAlive = false;

		// play corresponding animation and sound
		_anim.Play("Die");
		AudioManager.instance.PlayAudio(AudioManager.GameAudioEnum.Laser);

		// send message to GameManager
		GameManager.instance.isGameOver = true;
	}
}
