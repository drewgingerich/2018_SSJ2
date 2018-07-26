using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickInterceptor : MonoBehaviour {

	public abstract bool CheckForIntercept(RaycastHit hit);

	public virtual void Intercept() {
		return;
	}
}
