using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	// enum to switch between different audio clips
	public enum GameAudioEnum { Coin, Laser, JetPack }

	// make this a singleton
	public static AudioManager instance = null;

	// reference to audio source
	private AudioSource _audioSource;

	// store all clips
	[SerializeField] private AudioClip _coinCollect;
	[SerializeField] private AudioClip _laserZap;
	[SerializeField] private AudioClip _jetpack;

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

	// Use this for initialization
	void Start () 
	{
		_audioSource = GetComponent<AudioSource>();
	}
	
	public void PlayAudio(GameAudioEnum audioType)
	{
		switch (audioType)
		{
			case GameAudioEnum.Coin: 
				_audioSource.clip = _coinCollect;
				break;

			case GameAudioEnum.Laser: 
				_audioSource.clip = _laserZap;
				break;

			case GameAudioEnum.JetPack:
				_audioSource.clip = _jetpack;
				break;
		}

		_audioSource.Play();
	}
}
