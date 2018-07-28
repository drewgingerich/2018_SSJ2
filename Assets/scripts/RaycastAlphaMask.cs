using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class RaycastAlphaMask : ClickInterceptor {

	[SerializeField] float threshold = 0.01f;

	Texture2D tex;

	void Awake() {
		tex = Instantiate(GetComponent<MeshRenderer>().material.mainTexture as Texture2D);
	}

	public override bool CheckForIntercept(RaycastHit hit) {
		Vector2 pixelUV = hit.textureCoord;
		pixelUV.x *= tex.width;
		pixelUV.y *= tex.height;
		Color pixelColor = tex.GetPixel((int)pixelUV.x, (int)pixelUV.y);
		if (pixelColor.a <= threshold) {
			return false;
		} else {
			return true;
		}
	}
}
