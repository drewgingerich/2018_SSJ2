using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue")]
public class Dialogue : ScriptableObject {

	[SerializeField] List<DialogueLine> lines;

	public List<DialogueLine> Lines { 
		get { return lines; }
	}
}
