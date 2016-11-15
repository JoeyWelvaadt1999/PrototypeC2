using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Collectables : MonoBehaviour {
	[SerializeField]private Text _text;
	private int _collectables;

	private void Update() {
		_text.text = _collectables.ToString ();
	}

	public void AddCollectable(int value) {
		_collectables += value;
	}
}
