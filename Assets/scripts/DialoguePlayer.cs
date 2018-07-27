using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialoguePlayer : MonoBehaviour {

	public UnityEvent OnFinish;

	[SerializeField] Typewriter typewriter;
	[SerializeField] Dialogue dialogue;

	public void Activate() {
		typewriter.OnFinish += Finish;
		typewriter.TypeDialogue(dialogue);
	}

	void Finish() {
		typewriter.OnFinish -= Finish;
		OnFinish.Invoke();
	}
}
