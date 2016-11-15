using UnityEngine;
using System.Collections;

public class BackgroundSize : MonoBehaviour {
	private Vector2 _pixelSize = new Vector2(1280, 720);

	private void Start () {
		GetSize ();
	}

	public Vector2 GetSize() {
		float height = Camera.main.orthographicSize * 2;
		float width = height * Camera.main.aspect;
		transform.localScale = new Vector2 (width / (_pixelSize.x / 100), height / (_pixelSize.y / 100));
		return new Vector2 (width / (_pixelSize.x / 100), height / (_pixelSize.y / 100));
	}
}
