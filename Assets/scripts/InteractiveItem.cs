using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveItem : Interactable {

	[SerializeField] ItemDisplay itemDisplay;
	[SerializeField] Item item;

	protected override void Interact() {
		itemDisplay.DisplayItem(item, Finish);
	}

	void Finish() {
		OnFinishInteracting.Invoke(this);
	}
}
