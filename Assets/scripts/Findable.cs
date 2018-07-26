using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class Findable : ClickInterceptor {

	System.Action<Findable> onFind;

	[SerializeField] bool active = false;

	public override bool CheckForIntercept(RaycastHit hit) {
		return active;
	}

	public override void Intercept() {
		if (onFind != null)
			onFind(this);
	}
	public void Activate(System.Action<Findable> onFind) {
		this.onFind = onFind;
		gameObject.SetActive(true);
		active = true;
	}

	public void Deactivate() {
		active = false;
	}
}
