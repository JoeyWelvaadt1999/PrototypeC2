using UnityEngine;
using System.Collections;

public enum SwipeDirection {
	Right,
	Left,
	Up,
	Down,
	None
}

public class MobileInput : MonoBehaviour {
	private Vector2 _beginTouch;
	private Vector2 _endTouch;
	private SwipeDirection _sd;
	private PlayerJump _jump;
	private PlayerAttack _attack;
	private bool _swiped;

	private void Start() {
		_jump = GetComponent<PlayerJump> ();
		_attack = GetComponent<PlayerAttack> ();
	}

	private void Update() {
		InitSwipe ();
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			CalculateSwipe (Vector2.zero, new Vector2 (3, 0));
			InitSwipe ();
		}

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			CalculateSwipe (Vector2.zero, new Vector2 (0, 3));
			InitSwipe ();
		}
	}

	private void Swipe () {
		float totalTouches = Input.touchCount;
		if (totalTouches >= 1) {
			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Began) {
				_beginTouch = touch.position;
			} else if (touch.phase == TouchPhase.Moved) {
				_endTouch = touch.position;
			} else if (touch.phase == TouchPhase.Ended) {
				_endTouch = touch.position;
				CalculateSwipe (_beginTouch, _endTouch);
			}
		}
	}

	private void InitSwipe() {
		Swipe ();
	
		switch (_sd) {
		case SwipeDirection.Up:
			_jump.JumpByRigidbody ();
			ResetSwipe ();
			break;
		case SwipeDirection.Down:
			break;
		case SwipeDirection.Left:
			break;
		case SwipeDirection.Right:
			_attack.Attack ();
			ResetSwipe ();
			break;
		default:
			break;
		}

	}

	private void CalculateSwipe(Vector2 a, Vector2 b) {
		float x = b.x - a.x;
		float y = b.y - a.y;

		if (y > x) {
			if (y > 0) {
				_sd = SwipeDirection.Up;
			} else {
				_sd = SwipeDirection.Down;
			}
		}

		if (x > y) {
			if (x > 0) {
				_sd = SwipeDirection.Right;
			} else  {
				_sd = SwipeDirection.Left;
			}
		}
	}

	private void ResetSwipe() {
		_beginTouch = Vector2.zero;
		_endTouch = Vector2.zero;
		_sd = SwipeDirection.None;
	}
}
