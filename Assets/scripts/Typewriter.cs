using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour {

	public System.Action OnFinish = delegate {};

	[SerializeField] Text textBox;
	[SerializeField] List<DialogueLine> lines;

	const string hideTags = "<color=#00000000></color>";
	int hideTagLength;
	int closingTagLength;

	int textIndex;
	StringBuilder sb;

	void Awake() {
		hideTagLength = hideTags.Length;
		closingTagLength = "</color>".Length;
	}

	public void TypeDialogue(Dialogue dialogue) {
		gameObject.SetActive(true);
		StartCoroutine(TypeDialogueRoutine(dialogue));
	}

	IEnumerator TypeDialogueRoutine(Dialogue dialogue) {
		sb = new StringBuilder();
		sb.Append(hideTags);
		foreach (DialogueLine line in dialogue.Lines) {
			yield return StartCoroutine(TypeTextRoutine(line));
			yield return new WaitForSeconds(line.finishPauseTime);
		}
		OnFinish();
		gameObject.SetActive(false);
	}

	IEnumerator TypeTextRoutine(DialogueLine line) {
		string colorhex = ColorUtility.ToHtmlStringRGB(line.character.color);
		sb.Insert(sb.Length - hideTagLength, '\n');
		sb.Insert(sb.Length - hideTagLength, '\n');
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
}
