using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]private float _speed;

	private void Update() {
		Vector2 position = transform.position;
		position.x += _speed * Time.deltaTime;
		transform.position = position;
	}

}
