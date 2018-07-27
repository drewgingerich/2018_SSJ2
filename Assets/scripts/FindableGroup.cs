using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FindableGroup : MonoBehaviour {

	public UnityEvent OnFinish;

	[SerializeField] List<Findable> items;

	List<Findable> found;

	void Awake() {
		found = new List<Findable>();
	}

	public void Activate() {
		foreach (Findable findable in items) {
			findable.OnFind.AddListener(FindItem);
			findable.Activate();
		}
	}

	void FindItem(Findable item) {
		items.Remove(item);
		if (items.Count == 0)
			Finish();
	}

	void Finish() {
		OnFinish.Invoke();
	}
}
