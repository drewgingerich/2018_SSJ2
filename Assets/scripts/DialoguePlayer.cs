using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialoguePlayer : MonoBehaviour {

	public UnityEvent OnFinish;

	[SerializeField]
	private DialogueDisplay display;
	[SerializeField]
	private Dialogue dialogue;

	public void Activate() {
		display.DisplayDialogue(dialogue, Finish);
	}

	void Finish() {
		OnFinish.Invoke();
	}
}
