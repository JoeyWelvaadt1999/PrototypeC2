using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
	[SerializeField]private float _speed;
	private float _sizeX;

	public float Speed {
		get { 
			return _speed;
		} set { 
		
			_speed = value;
		}
	}

	private void Start() {
		_sizeX = GetComponent<SpriteRenderer> ().bounds.size.x;
	}

	private void Update() {
		Vector3 pos = transform.position;
		pos.x -= _speed * Time.deltaTime;
		transform.position = pos;
		CheckPos ();
	}

	private void CheckPos() {
		Camera camera = Camera.main;
		float height = 2 * camera.orthographicSize;
		float width = height * camera.aspect;
		if (transform.position.x + _sizeX / 2 < camera.transform.position.x - width / 2) {
			Vector3 pos = transform.position;
			pos.x += width * 4 ;
			transform.position = pos;
		}
	}
}
