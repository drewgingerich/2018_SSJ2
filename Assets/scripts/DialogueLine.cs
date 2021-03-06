﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Line")]
public class DialogueLine : ScriptableObject {

	public DialogueCharacter character;
	[TextArea(10, 15)] public string text;
	public float textSpeed = 0.03f;
	public float finishPauseTime = 2f;
}
