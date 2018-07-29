using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueDisplay : MonoBehaviour {

	public UnityEvent OnStart;
	public UnityEvent OnEnd;

	[SerializeField] Typewriter typewriter;

	public void DisplayDialogue(Dialogue dialogue, System.Action callback) {
		StopAllCoroutines();
		gameObject.SetActive(true);
		StartCoroutine(DisplayDialogueRoutine(dialogue, callback));
	}

	IEnumerator DisplayDialogueRoutine(Dialogue dialogue, System.Action callback) {
		OnStart.Invoke();
		yield return StartCoroutine(typewriter.TypeDialogueRoutine(dialogue));
		callback();
		OnEnd.Invoke();
		yield return null;
		gameObject.SetActive(false);
	}
}
