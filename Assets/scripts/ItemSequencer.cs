using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Sequence")]
public class ItemSequencer : ScriptableObject {

	[SerializeField] List<Item> sequence;

	int index = 0;

	public Item GetNextItem() {
		if (index == sequence.Count)
			return null;
		Item item = sequence[index];
		index++;
		return item;
	}
}
