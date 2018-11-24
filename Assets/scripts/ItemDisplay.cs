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
	[SerializeField] Typewriter thoughtTypewriter;
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
		yield return StartCoroutine(thoughtTypewriter.TypeDialogueRoutine(item.thoughts));
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
