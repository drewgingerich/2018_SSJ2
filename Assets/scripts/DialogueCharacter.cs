using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Character")]
public class DialogueCharacter : ScriptableObject {

	public new string name;
	public Color color;
	[Range(.7f, 1.2f)] public float pitch = 1;
}
