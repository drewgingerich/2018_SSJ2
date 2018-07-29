using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour {

	[SerializeField] Text textBox;
	[SerializeField] bool clearLines = false;

	const string hideTags = "<color=#00000000></color>";
	int hideTagLength;
	int closingTagLength;

	int textIndex;
	StringBuilder sb;

	void Awake() {
		hideTagLength = hideTags.Length;
		closingTagLength = "</color>".Length;
	}

	public IEnumerator TypeDialogueRoutine(Dialogue dialogue) {
		PrepareStringBuilder();
		foreach (DialogueLine line in dialogue.Lines) {
			yield return StartCoroutine(TypeTextRoutine(line));
			yield return new WaitForSeconds(line.finishPauseTime);
			if (clearLines) {
				PrepareStringBuilder();
			} else {
				sb.Insert(sb.Length - hideTagLength, '\n');
				sb.Insert(sb.Length - hideTagLength, '\n');
			}
		}
		textBox.text = "";
	}

	public IEnumerator TypeTextRoutine(DialogueLine line) {
		string colorhex = ColorUtility.ToHtmlStringRGB(line.character.color);

		sb.Insert(sb.Length - hideTagLength, string.Format("<color=#{0}></color>", colorhex));
		sb.Insert(sb.Length - closingTagLength, line.text);
		int lineIndex = 0;

		while (true) {
			int remainingChars = line.text.Length - lineIndex;
			int index = sb.Length - closingTagLength - remainingChars;
			sb.Remove(index, 1);
			sb.Insert(index - hideTagLength, line.text[lineIndex]);
			textBox.text = sb.ToString();
			lineIndex++;
			if (lineIndex == line.text.Length)
				break;
			yield return new WaitForSeconds(line.textSpeed);
		}
	}

	void PrepareStringBuilder() {
		sb = new StringBuilder();
		sb.Append(hideTags);
	}
}
