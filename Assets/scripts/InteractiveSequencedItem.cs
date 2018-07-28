using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSequencedItem : InteractiveItem {

	[SerializeField] ItemDisplay itemDisplay;
	[SerializeField] ItemSequencer itemSequence;

	Item item;

	public override void Intercept() {
		if (item == null)
			item = itemSequence.GetNextItem();
		itemDisplay.DisplayItem(item, Finish);
	}

	void Finish() {
		OnFinishInteracting.Invoke(this);
	}
}
