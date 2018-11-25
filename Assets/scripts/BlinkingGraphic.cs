using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingGraphic : MonoBehaviour {

	[SerializeField]
	private Graphic graphic;
	[SerializeField]
	private float showTime = 0.5f;
	[SerializeField]
	private float hideTime = 0.25f;
	[SerializeField]
	private bool hideOnStop = true;

	private bool stopFlag = false;

	private float timer = 0f;

	void Start() {
		graphic.enabled = false;
	}

	public void StartBlinking() {
		StartCoroutine(BlinkingRoutine());
	}	

	public IEnumerator BlinkingRoutine() {
		graphic.enabled = true;
		timer = 0;
		while (true) {
			if (stopFlag) {
				stopFlag = false;
				break;
			}
			UpdateBlinkState();
			yield return null;
		}
		graphic.enabled = hideOnStop ? false : true;
	}

	void UpdateBlinkState() {
		timer += Time.deltaTime;

		if (graphic.enabled && timer >= showTime) {
			timer -= showTime;
			graphic.enabled = false;
		} else if (!graphic.enabled && timer >= hideTime) {
			timer -= hideTime;
			graphic.enabled = true;
		}
	}

	public void StopBlinking() {
		stopFlag = true;
	}
}
