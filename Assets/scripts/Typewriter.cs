using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour {

	[SerializeField] TypewriterAudio typewriterAudio;
	[SerializeField] Text textBox;
	[SerializeField] bool clearLines = false;
	[SerializeField] bool clearOnFinish = false;

	const string hideTags = "<color=#00000000></color>";
	int hideTagLength;
	int closingTagLength;

	void Awake() {
		hideTagLength = hideTags.Length;
		closingTagLength = "</color>".Length;
	}

	public IEnumerator TypeDialogueRoutine(Dialogue dialogue, int spaceBetweenLines = 1) {
		StringBuilder sb = PrepareStringBuilder();
		foreach (DialogueLine line in dialogue.Lines) {
			yield return StartCoroutine(TypeTextRoutine(line, sb));
			yield return new WaitForSeconds(line.finishPauseTime);
			if (clearLines) {
				sb = PrepareStringBuilder();
			} else {
				for (int i = 0; i < spaceBetweenLines + 1; i++) {
					sb.Insert(sb.Length - hideTagLength, '\n');
				}
			}
		}
		if (clearOnFinish)
			textBox.text = "";
	}

	public IEnumerator TypeTextRoutine(DialogueLine line , StringBuilder sb) {
		typewriterAudio.SetCharacter(line.character);

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
			if (line.text[lineIndex - 1] != ' ')
				typewriterAudio.PlayClip();
			yield return new WaitForSeconds(line.textSpeed);
		}
	}

	public void ClearText() {
		textBox.text = "";
	}

	StringBuilder PrepareStringBuilder() {
		StringBuilder sb = new StringBuilder();
		sb.Append(hideTags);
		return sb;
	}
}
