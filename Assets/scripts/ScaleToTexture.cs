using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
public class ScaleToTexture : MonoBehaviour {

	[SerializeField] int pixPerUnit = 900;

	new MeshRenderer renderer;
	
	void Awake() {
		renderer = GetComponent<MeshRenderer>();
	}

	void Update() {
		Texture texture = renderer.sharedMaterial.mainTexture;
		Vector2 size = new Vector2(texture.width, texture.height) / pixPerUnit;
		transform.localScale = (Vector3)size;
	}
}
