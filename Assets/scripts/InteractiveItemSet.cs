using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItemSet : Interactable {

	[SerializeField] ItemDisplay itemDisplay;
	[SerializeField] List<Item> items;

	int itemIndex;

	protected override void Interact() {
		itemIndex = 0;
		DisplayNextItem();
	}

	void DisplayNextItem() {
		if (itemIndex == items.Count) {
			Finish();
		} else {
			itemDisplay.DisplayItem(items[itemIndex], DisplayNextItem);
			itemIndex++;
		}
	}

	void Finish() {
		OnFinishInteracting.Invoke(this);
	}
}
