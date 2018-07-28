using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InteractableEvent : UnityEvent<Interactable> {}

public class Interactable : ClickInterceptor {

	public UnityEvent OnInteract;
	public InteractableEvent OnFinishInteracting;

	[SerializeField] protected bool active;

	public void Activate() {
		active = true;
	}

	public override void Intercept() {
		if (!active)
			return;
		OnInteract.Invoke();
		Interact();
	}

	protected virtual void Interact() {
		OnFinishInteracting.Invoke(this);
	}
}
