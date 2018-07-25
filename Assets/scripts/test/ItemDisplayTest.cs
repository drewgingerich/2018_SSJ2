using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplayTest : MonoBehaviour {

	[SerializeField] ItemDisplay display;
	[SerializeField] Item item;

	void Start () {
		display.DisplayItem(item);
	}
}
