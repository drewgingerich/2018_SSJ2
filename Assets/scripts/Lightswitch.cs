using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class Lightswitch : MonoBehaviour {

	[SerializeField] bool toggle = false;

	new Light light;

	void Awake() {
		light = GetComponent<Light>();
	}

	void Start() {
		light.enabled = toggle;
	}

	public void ToggleSwitch() {
		toggle = !toggle;
		light.enabled = toggle;
	}
}
