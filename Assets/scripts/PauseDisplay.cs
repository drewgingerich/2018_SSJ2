using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PauseDisplay : MonoBehaviour {

	public UnityEvent OnPause;
	public UnityEvent OnUnpause;
	
	[SerializeField] GameObject pauseMenu;
	[SerializeField] Text goalText;

	bool paused;

	void Start() {
		pauseMenu.SetActive(false);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
			TogglePause();
	}

	public void TogglePause() {
		paused = !paused;
		if (paused)
			Pause();
		else
			Unpause();
	}

	void Pause() {
		pauseMenu.SetActive(true);
		Time.timeScale = 0;
		OnPause.Invoke();
	}

	void Unpause() {
		pauseMenu.SetActive(false);
		Time.timeScale = 1;
		OnUnpause.Invoke();
	}

	public void SetGoalText(string text) {
		goalText.text = text;
	}
}
