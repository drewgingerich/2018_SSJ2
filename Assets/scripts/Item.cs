using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item")]
public class Item : ScriptableObject {

	public Texture2D picture;
	[TextArea(5, 10)] public string description;
	[TextArea(10, 15)] public string text;
}
