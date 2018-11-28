using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Dialogue/Line")]
public class DialogueLine : ScriptableObject {

	public DialogueCharacter character;
	[TextArea(10, 15)] public string text;
	public float textSpeed = 0.03f;
	[FormerlySerializedAs("waitForInputWhenDone")]
	public bool waitForInput = true;
	public float finishPauseTime = 0.5f;
}
