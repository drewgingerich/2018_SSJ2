using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour {

	[SerializeField] Text textBox;
	[SerializeField] float charTime = 0.05f;
	[SerializeField] float nameTime = 0.2f;
	[SerializeField] float lineTime = 1.5f;
	[SerializeField] List<DialogueLine> lines;

	const string hideTags = "<color=#000000ff></color>";
	int hideTagLength;
	int closingTagLength;

	int textIndex;
	StringBuilder sb;

	void Awake() {
		hideTagLength = hideTags.Length;
		closingTagLength = "</color>".Length;
		sb = new StringBuilder();
		sb.Append(hideTags);
	}

	void Start() {
		StartCoroutine(RunDialogue());
	}

	IEnumerator RunDialogue() {
		foreach (DialogueLine line in lines) {
			yield return StartCoroutine(TypeText(line));
			yield return new WaitForSeconds(lineTime);
		}
	}

	IEnumerator TypeText(DialogueLine line) {
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
			yield return new WaitForSeconds(charTime);
		}
	}
}
