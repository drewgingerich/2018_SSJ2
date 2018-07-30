using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventRepeater : MonoBehaviour {

	public UnityEvent OnReceive;
	public UnityEvent OnRepeat;

	[SerializeField] bool delay;
	[SerializeField] float delayTime;

	public void Receive() {
		OnReceive.Invoke();
		StartCoroutine(Delay(delayTime));
	}

	IEnumerator Delay(float time) {
		yield return new WaitForSeconds(time);
		OnRepeat.Invoke();
	}
}
