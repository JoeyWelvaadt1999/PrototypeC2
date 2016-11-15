using UnityEngine;
using System.Collections;

public class ParallaxScrolling : MonoBehaviour {
	[SerializeField]private GameObject[] _backgrounds;
	private float[] _backgroundSizeX;
	private int _size = 5;

	private void Start() {
		_backgroundSizeX = new float[_backgrounds.Length];
		for (int i = 0; i < _backgrounds.Length; i++) {
			_backgroundSizeX [i] = _backgrounds [i].GetComponent<SpriteRenderer> ().bounds.size.x;

		}

		for (int k = 0; k < _backgrounds.Length; k++) {
			
			for (int j = 0; j < _size; j++) {
				GameObject bg = Instantiate (_backgrounds [k], new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				bg.transform.position = new Vector3 (Camera.main.transform.position.x + ((Camera.main.orthographicSize * 2) * Camera.main.aspect) * j, Camera.main.transform.position.y,0);
				bg.transform.parent = transform;
			}
		}
	}
}
