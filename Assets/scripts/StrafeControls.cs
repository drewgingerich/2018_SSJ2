using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafeControls : MonoBehaviour {

	[SerializeField] float speed = 1;
	[SerializeField] float maxDistance = 3;
	
	void Update () {
		float input = Input.GetAxisRaw("Horizontal");
		if (input == 0)
			return;
		float move = input * speed * Time.deltaTime;
		Vector3 newPosition = transform.position + new Vector3(move, 0, 0);
		newPosition.x = Mathf.Clamp(newPosition.x, -maxDistance, maxDistance);
		transform.position = newPosition;
	}
}
