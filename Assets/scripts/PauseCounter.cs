using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseCounter : MonoBehaviour {

	public UnityEvent OnPause;
	public UnityEvent OnUnpause;
	
	int counter = 0;

	public void Pause() {
		if (counter == 0)
			OnPause.Invoke();
		counter++;
	}

	public void Unpause() {
		counter--;
		if (counter == 0)
			OnUnpause.Invoke();
	}
}
