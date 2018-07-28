using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public abstract class ClickInterceptor : MonoBehaviour {

	public virtual bool CheckForIntercept(RaycastHit hit) {
		return true;
	}

	public virtual void Intercept() {
		return;
	}
}
