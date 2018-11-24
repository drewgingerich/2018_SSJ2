using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFeed {

	public int lineBreakSize;
	public bool clearLines;

	private const string hideTags = "<color=#00000000></color>";
	private const string colorTagsTemplate = "<color=#{0}></color>";

	private readonly int openingTagLength = "<color=#00000000>".Length;
	private readonly int closingTagLength = "</color>".Length;

	private string lineText;

	private StringBuilder sb;

	private int visibleTextIndex;
	private int hiddenTextIndex;
	private int characterIndex;

	public TextFeed() {
		sb = new StringBuilder(64);
	}

	public void LoadLine(DialogueLine line) {
		lineText = line.text;

		if (clearLines) {
			Clear();
		}

		visibleTextIndex = sb.Length + openingTagLength;
		hiddenTextIndex = sb.Length + openingTagLength * 2 + closingTagLength;
		characterIndex = 0;

		string colorhex = ColorUtility.ToHtmlStringRGBA(line.character.color);
		sb.Append(string.Format("<color=#{0}></color>", colorhex));
		sb.Append(hideTags);
		sb.Insert(hiddenTextIndex, line.text);
	}

	public bool ShowNextChar(out string newText) {
		if (characterIndex + 1 < lineText.Length) {
			RevealChars(1);
			newText = sb.ToString();
			return true;
		} else {
			newText = sb.ToString();
			return false;
		}
	}

	public string ShowAllChars() {
		RevealChars(lineText.Length - characterIndex);
		return sb.ToString();
	}

	public void AddLineBreak() {
		sb.Append('\n' * lineBreakSize);
	}

	public void Clear() {
		sb.Length = 0;
		sb.Capacity = 64;	
	}

	void RevealChars(int number) {
		sb.Remove(hiddenTextIndex, number);
		string textToReveal = lineText.Substring(characterIndex, number);
		sb.Insert(visibleTextIndex, textToReveal);

		hiddenTextIndex += number;
		visibleTextIndex += number;
		characterIndex += number;
	}
}
