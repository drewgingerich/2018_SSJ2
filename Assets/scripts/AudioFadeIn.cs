using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioFadeIn : MonoBehaviour {

	public UnityEvent OnFinish;

	[SerializeField] AudioSource audioSource;
	[SerializeField] bool onStart = false;
	[SerializeField] float fadeTime = 1;

	void Start() {
		if (onStart) {
			StartCoroutine(FadeIn());
		}
	}

	public IEnumerator FadeIn() {
		float inverseFadeTime = 1 / fadeTime;
		float progress = 0;
		float targetVolume = audioSource.volume;
		audioSource.volume = 0;
		while (audioSource.volume < targetVolume) {
			progress += Time.deltaTime * inverseFadeTime;
			audioSource.volume = Mathf.Lerp(0, targetVolume, progress);
			yield return null;
		}
		OnFinish.Invoke();
	}
}
