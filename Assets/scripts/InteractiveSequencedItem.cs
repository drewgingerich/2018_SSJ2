using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSequencedItem : Interactable {

	[SerializeField] ItemDisplay itemDisplay;
	[SerializeField] ItemSequencer itemSequence;

	Item item;

	protected override void Interact() {
		if (item == null)
			item = itemSequence.GetNextItem();
		itemDisplay.DisplayItem(item, Finish);
	}

	void Finish() {
		OnFinishInteracting.Invoke(this);
	}
}
