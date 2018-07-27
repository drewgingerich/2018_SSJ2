using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshCollider))]
public class Findable : ClickInterceptor {

	public UnityEvent OnIntercept;
	public UnityEvent<Findable> OnFind;

	[SerializeField] ItemDisplay itemDisplay;
	[SerializeField] Item item;
	[SerializeField] bool active = false;

	public void Activate() {
		gameObject.SetActive(true);
		active = true;
	}

	public override void Intercept() {
		if (!active)
			return;
		OnIntercept.Invoke();
		itemDisplay.OnFinish += Find;
		itemDisplay.DisplayItem(item);
	}

	void Find() {
		itemDisplay.OnFinish -= Find;
		OnFind.Invoke(this);
	}
}
