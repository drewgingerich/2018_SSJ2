using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour {

	[SerializeField] DialogueCharacter character;
	[SerializeField] RawImage picture;
	[SerializeField] Text text;
	[SerializeField] float textSpeed = 0.03f;
	[SerializeField] float thoughtPauseTime = 1.5f;

	public void DisplayItem(Item item) {
		gameObject.SetActive(true);
		picture.texture = item.picture;
		StartCoroutine(DisplayText(item));
	}

	IEnumerator DisplayText(Item item) {
		yield return null;

		StringBuilder sb = new StringBuilder();
		string charColor = ColorUtility.ToHtmlStringRGB(character.color);
		sb.AppendFormat("<i><color=#{0}></color><color=#000000ff>{1}</color></i>", charColor, item.description);

		int endTagLength = "</color></i>".Length;
		int visibleTextOffset = "</color><color=#000000ff>".Length;

		for (int i = 0; i < item.description.Length; i++) {
			int currentIndex = sb.Length - endTagLength - item.description.Length + i;
			sb.Remove(currentIndex, 1);
			sb.Insert(currentIndex - visibleTextOffset, item.description[i]);
			text.text = sb.ToString();
			yield return new WaitForSeconds(textSpeed);
		}

		while (!CheckForInterrupt()) {
			yield return null;
		}
		yield return null;

		// float timer = 0;
		// while (!CheckForInterrupt() && timer < thoughtPauseTime) {
		// 	timer += Time.deltaTime;
		// 	yield return null;
		// }

		sb.Append('\n');
		sb.Append('\n');
		sb.Append(item.text);
		text.text = sb.ToString();

		while (!CheckForInterrupt()) {
			yield return null;
		}

		gameObject.SetActive(false);
	}

	bool CheckForInterrupt() {
		return Input.GetMouseButtonUp(0)
			|| Input.GetKeyUp(KeyCode.Return)
			|| Input.GetKeyUp(KeyCode.Space)
			|| Input.GetKeyUp(KeyCode.DownArrow);
	}
}
