using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {
	[SerializeField]private float _unitsX;
	[SerializeField]private float _unitsY;
	private float _frames = 0.18f;
	private Rigidbody2D _rb2d;
	private AnimationState _state;
	private bool _isJumping = false;

	private void Start() {
		_rb2d = GetComponent<Rigidbody2D> ();
		_state = GetComponent<AnimationState> ();
	}

	private void Update () {
		if (_rb2d.velocity.y > 0.1f) {
			_isJumping = true;
			//set animation state to jumping
			_state.SetState(States.Jumping);
		} else if (_rb2d.velocity.y < -0.1f) { 
			_isJumping = true;
			//set animation state to falling
			_state.SetState(States.Falling);
		} else {
			_isJumping = false;
			//set animation state to running
			_state.SetState(States.Running);
		}
	}

	public void JumpByRigidbody() {
		if (!_isJumping) {
			_rb2d.AddForce (new Vector2 (_unitsX, _unitsY), ForceMode2D.Impulse);

		}
	}

	private IEnumerator CalculateJumpBySpeed() {
		Vector2 curPos = transform.position;
		float newPosX = curPos.x + _unitsX;
		float newPosY = curPos.y + _unitsY;

		while (transform.position.x < newPosX && transform.position.y < newPosY) {
			Vector2 newPos = transform.position;
			newPos.x += newPosX * _frames;
			newPos.y += newPosY * _frames;
			transform.position = newPos;
			yield return 0;
		}
	}
}
