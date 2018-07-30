using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ItemDisplay : MonoBehaviour {

	public UnityEvent OnStart;
	public UnityEvent OnEnd;

	[SerializeField] RawImage picture;
	[SerializeField] Typewriter topTypewriter;
	[SerializeField] Typewriter midTypewriter;
	[SerializeField] Text itemTextBox;
	[SerializeField] GameObject nextButton;

	bool interrupted = false;

	public void DisplayItem(Item item, System.Action callback) {
		StopAllCoroutines();
		gameObject.SetActive(true);
		nextButton.SetActive(false);
		picture.texture = item.picture;
		StartCoroutine(DisplayItemRoutine(item, callback));
	}

	public void Interrupt() {
		interrupted = true;
	}

	IEnumerator DisplayItemRoutine(Item item, System.Action callback) {
		OnStart.Invoke();
		bool itemTextIsPresent = item.text != null;
		itemTextBox.text = itemTextIsPresent ? item.text.text : "";
		Typewriter selectedTypewriter = itemTextIsPresent ? topTypewriter : midTypewriter;
		yield return StartCoroutine((selectedTypewriter.TypeDialogueRoutine(item.thoughts, spaceBetweenLines:0)));
		nextButton.SetActive(true);
		while (!CheckForInterrupt()) {
			yield return null;
		}
		callback();
		OnEnd.Invoke();
		yield return null;
		gameObject.SetActive(false);
	}

	bool CheckForInterrupt() {
		if (interrupted) {
			interrupted = false;
			return true;
		} else {
			return false;
		}
	}
}
