using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ThoughtDisplay : MonoBehaviour {

	[SerializeField] Text text;
	[SerializeField] DialogueCharacter character;
	[SerializeField] float textSpeed;

	public static ThoughtDisplay instance;

	void Awake() {
		Debug.Assert(instance == null);
		instance = this;
	}

	public void DisplayThought(string thought) {
		DisplayText(thought);
	}

	public IEnumerator DisplayText(string thought) {
		StringBuilder sb = new StringBuilder();
		string charColor = ColorUtility.ToHtmlStringRGB(character.color);
		sb.AppendFormat("<i><color=#{0}></color></i>", charColor);

		int endTagLength = "</color></i>".Length;

		for (int i = 0; i < thought.Length; i++) {
			sb.Insert(sb.Length - endTagLength, thought[i]);
			text.text = sb.ToString();
			yield return new WaitForSeconds(textSpeed);
		}
	}

}
