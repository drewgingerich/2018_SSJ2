using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TypewriterAudio : MonoBehaviour {

	[SerializeField] AudioClip clip;
	[SerializeField] int skipped = 1;

	AudioSource audioSource;
	DialogueCharacter character;
	int timesPlayed = 0;

	void Awake() {
		audioSource = GetComponent<AudioSource>();
	}

	void Start() {
		audioSource.clip = clip;
		audioSource.volume = 0.2f;
	}

	public void SetCharacter(DialogueCharacter character) {
		this.character = character;
	}

	public void PlayClip() {
		if (timesPlayed == 0) {
			audioSource.Play();
			audioSource.time = 0;
			audioSource.pitch = character.pitch + Random.Range(-0.1f, 0.1f);
		}
		timesPlayed++;
		timesPlayed %= skipped;
	}
}
