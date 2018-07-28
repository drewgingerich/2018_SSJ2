using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Typewriter : MonoBehaviour {

	public UnityEvent OnStart;
	public UnityEvent OnEnd;

	[SerializeField] Text textBox;
	[SerializeField] List<DialogueLine> lines;
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

	public void TypeDialogue(Dialogue dialogue, System.Action callback) {
		StopAllCoroutines();
		gameObject.SetActive(true);
		StartCoroutine(TypeDialogueRoutine(dialogue, callback));
	}

	IEnumerator TypeDialogueRoutine(Dialogue dialogue, System.Action callback) {
		OnStart.Invoke();
		PrepareStringBuilder();
		foreach (DialogueLine line in dialogue.Lines) {
			yield return StartCoroutine(TypeTextRoutine(line));
			if (clearLines) {
				PrepareStringBuilder();
			} else {
				sb.Insert(sb.Length - hideTagLength, '\n');
				sb.Insert(sb.Length - hideTagLength, '\n');
			}
			yield return new WaitForSeconds(line.finishPauseTime);
		}
		OnEnd.Invoke();
		callback();
		yield return null;
		gameObject.SetActive(false);
	}

	void PrepareStringBuilder() {
		sb = new StringBuilder();
		sb.Append(hideTags);
	}

	IEnumerator TypeTextRoutine(DialogueLine line) {
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
}
