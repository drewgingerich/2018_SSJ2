using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypewriterAudio : MonoBehaviour {

	[SerializeField] Transform playTarget;
	[SerializeField] List<AudioClip> clips;
	[SerializeField] float speed = 1;

	float waitTime;
	AudioClip lastPlayed;
	Coroutine routine;

	void Awake() {
		float baseWaitTime = 0.1f;
		waitTime = baseWaitTime / speed;
	}

	public void PlayAudio() {
		routine = StartCoroutine(PlayAudioRoutine());
	}

	public void StopAudio() {
		StopCoroutine(routine);
	}

	IEnumerator PlayAudioRoutine() {
		while (true) {
			PlayClip();
			yield return new WaitForSeconds(waitTime);
		}
	}

	void PlayClip() {
		int randomIndex = Random.Range(0, clips.Count);
		AudioClip selectedClip = clips[randomIndex];
		AudioSource.PlayClipAtPoint(selectedClip, playTarget.position);
		if (lastPlayed != null)
			clips.Add(lastPlayed);
		lastPlayed = selectedClip;
		clips.Remove(selectedClip);
	}
}
