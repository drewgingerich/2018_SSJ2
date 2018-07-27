using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshCollider))]
public class Findable : ClickInterceptor {

	public UnityEvent OnFind;
	System.Action<Findable> onFind;

	[SerializeField] bool active = false;

	public override bool CheckForIntercept(RaycastHit hit) {
		return true;
	}

	public override void Intercept() {
		if (!active)
			return;
		OnFind.Invoke();
		if (onFind != null)
			onFind(this);
	}

	public void Activate(System.Action<Findable> onFind) {
		this.onFind = onFind;
		gameObject.SetActive(true);
		active = true;
	}
}
