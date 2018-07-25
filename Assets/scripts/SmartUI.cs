using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SmartUI : MonoBehaviour {

	[SerializeField] bool center = true;
	[SerializeField] bool sleep = true;

	RectTransform rt;

	void Awake() {
		rt = GetComponent<RectTransform>();
		if (center)
			Center();
		if (sleep)
			Sleep();
	}

	void Center() {
		rt.offsetMin = Vector2.zero;
		rt.offsetMax = Vector2.zero;
	}

	void Sleep() {
		gameObject.SetActive(false);
	}
}
