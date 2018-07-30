using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item")]
public class Item : ScriptableObject {

	public Texture2D picture;
	public Dialogue thoughts;
	public DialogueLine text;
}
