using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour {

	[SerializeField] Transform movementReference;
	[SerializeField] Transform farReference;

	float origin;
	float movementOrigin;
	float movementRatio;

	void Start() {
		origin = transform.position.x;
		movementOrigin = movementReference.position.x;
		float referenceDepth = farReference.position.z - movementReference.position.z;
		float depth = movementReference.position.z - transform.position.z;
		movementRatio = depth / referenceDepth;
	}

	void Update () {
		float movement = movementReference.position.x - movementOrigin;
		Vector3 position = transform.position;
		position.x = movement * movementRatio;
	}
}
