using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {
	private CameraBounds _bounds;
	private AnimationState _state;
	private bool _isDeath = false;

	private PlayerAttack _pa;
	private PlayerMovement _pm;
	private PlayerJump _pj;

	private Rigidbody2D _rb2d;

	public bool IsDeath {
		get { 
			return _isDeath;
		}
	}

	private void Start() {
		_bounds = FindObjectOfType<CameraBounds> ();
		_state = GetComponent<AnimationState> ();

		_pa = GetComponent<PlayerAttack> ();
		_pm = GetComponent<PlayerMovement> ();
		_pj = GetComponent<PlayerJump> ();

		_rb2d = GetComponent<Rigidbody2D> ();

		_isDeath = false;
	}

	private void Update () {
		CheckDeathBounds ();
	}

	public void CheckDeathBounds () {
		if (_bounds.OutOfCameraBound (this.gameObject)) {
			Die (false);
		}
	}

	public void Die(bool wall) {
		_rb2d.gravityScale = 1;
		if (wall) {
			_rb2d.AddForce (new Vector2 (-50, 0), ForceMode2D.Impulse);
		}
			
		_isDeath = true;
		_state.SetState (States.Die);

		Parallax[] pss = FindObjectsOfType<Parallax> ();
		for (int i = 0; i < pss.Length; i++) {
			pss [i].Speed = 0;
		}


		_pa.enabled = false;
		_pm.enabled = false;
		_pj.enabled = false;

		//disable rigidbody (gravity)
		//game over screen needs to open
	}
}
