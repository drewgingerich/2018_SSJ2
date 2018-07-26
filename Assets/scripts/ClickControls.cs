using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControls : MonoBehaviour {

	RaycastHit[] hitBuffer = new RaycastHit[10];

	void Update () {
		if (Input.GetMouseButtonDown(0))
			Click();
		// else
		// 	Hover();
	}

	void Click() {
		ClickInterceptor interceptor = FindInteceptor();
		if (interceptor != null) {
			interceptor.Intercept();
		}
	}

	void Hover() {
		ClickInterceptor interceptor = FindInteceptor();
		if (interceptor != null)
			if (interceptor.GetComponent<Findable>() != null) {
				// glow sparks
			}
	}

	ClickInterceptor FindInteceptor() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		int hits = Physics.RaycastNonAlloc(ray, hitBuffer);
		Debug.Log(hits);

		ClickInterceptor activeInterceptor = null;

		for (int i = 0; i < hits; i++) {
			RaycastHit hit = hitBuffer[i];
			ClickInterceptor interceptor = hit.collider.GetComponent<ClickInterceptor>();
			if (interceptor == null || !interceptor.CheckForIntercept(hit))
				continue;
			if (activeInterceptor == null || interceptor.transform.position.z < activeInterceptor.transform.position.z)
				activeInterceptor = interceptor;
		}

		Debug.Log(activeInterceptor);
		return activeInterceptor;
	}
}
