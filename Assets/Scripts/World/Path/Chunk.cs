using UnityEngine;
using System.Collections;

public class Chunk : MonoBehaviour {
	[SerializeField]private GameObject[] _objects;

	public float GetChunkWidth () {
		float _min = float.MaxValue;
		float _max = float.MinValue;
		for (int i = 0; i < _objects.Length; i++) {
			Vector2 pos = _objects [i].transform.position;
			if (pos.x < _min) {
				_min = pos.x;
			} else if(pos.x > _max) {
				_max = pos.x;
			}
		}

		return (_max - _min);
	}

	public float GetObjectWidth() {
		SpriteRenderer sr = _objects [0].GetComponent<SpriteRenderer> ();
		return sr.sprite.border.x;

	}

	public Vector2 GetLastPosition() {
		float x = 0;
		float y = 0;
		for (int i = 0; i < _objects.Length; i++) {
			Vector2 pos = _objects [i].transform.position;
			if (pos.x > x) {
				x = pos.x;
			} 
			if (pos.y > y) {
				y = pos.y;
			}
		}

		return new Vector2 (x, y);
	}

	public void InstantiateChunk(Vector2 startPos) {
		for (int i = 0; i < _objects.Length; i++) {
			Instantiate (_objects [i], new Vector2 (_objects[i].transform.position.x + startPos.x, _objects[i].transform.position.y), Quaternion.identity);
		}
	}
}
