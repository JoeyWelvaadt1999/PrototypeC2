using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {
	[SerializeField]private int _value;
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			Collectables collect = coll.GetComponent<Collectables> ();
			collect.AddCollectable (_value);
			Destroy (this.gameObject);
		}
	}
}
