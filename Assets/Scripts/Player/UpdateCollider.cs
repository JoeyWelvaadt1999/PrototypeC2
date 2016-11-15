using UnityEngine;
using System.Collections;

public class UpdateCollider : MonoBehaviour {
	private bool _update = false;
	public bool UpdateColl {
		get { 
			return _update;
		} set { 
			_update = value;
		}
	}

	private void Update() {
		if (_update) {
			Destroy (GetComponent<BoxCollider2D> ());
			gameObject.AddComponent (typeof(BoxCollider2D));
		}
	}
}
