using UnityEngine;
using System.Collections;

public class WallBlock : MonoBehaviour {
	private PlayerDeath _pd;

	private void Start() {
		_pd = FindObjectOfType<PlayerDeath> ();
	}

	private void OnCollisionEnter2D(Collision2D coll) {
		_pd.Die (true);
			
	}
}
