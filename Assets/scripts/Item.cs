using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item")]
public class Item : ScriptableObject {

	public Texture2D picture;
	[TextArea] public string description;
	[TextArea] public string text;
}
