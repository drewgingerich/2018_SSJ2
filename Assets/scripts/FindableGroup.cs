using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FindableGroup : MonoBehaviour {

	public UnityEvent OnFinish;
	[SerializeField] List<Findable> items;
	[SerializeField] [TextArea] string thought;

	List<Findable> found;

	void Awake() {
		found = new List<Findable>();
	}

	public void ActivateGroup() {
		StartCoroutine(ActivationRoutine());
	}

	IEnumerator ActivationRoutine() {
		yield return StartCoroutine(ThoughtDisplay.instance.DisplayText(thought));
		foreach (Findable findable in items) {
			findable.Activate(FindItem);
		}
	}

	void FindItem(Findable item) {
		items.Remove(item);
		if (items.Count == 0)
			Finish();
	}

	void Finish() {
		OnFinish.Invoke();
	}
}
