using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialoguePlayer : MonoBehaviour {

	public UnityEvent OnFinish;

	[SerializeField] Typewriter typewriter;
	[SerializeField] Dialogue dialogue;

	public void Activate() {
		typewriter.TypeDialogue(dialogue, Finish);
	}

	void Finish() {
		OnFinish.Invoke();
	}
}
