using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableGroup : MonoBehaviour {

	public UnityEvent OnFinish;

	[SerializeField] List<Interactable> interactables;

	public void Activate() {
		foreach (InteractiveItem interactable in interactables) {
			interactable.OnFinishInteracting.AddListener(FindItem);
			Debug.Log(interactable.OnFinishInteracting);
			interactable.Activate();
		}
	}

	void FindItem(Interactable interactable) {
		interactable.OnFinishInteracting.RemoveListener(FindItem);
		interactables.Remove(interactable);
		if (interactables.Count == 0)
			Finish();
	}

	void Finish() {
		OnFinish.Invoke();
	}
}
