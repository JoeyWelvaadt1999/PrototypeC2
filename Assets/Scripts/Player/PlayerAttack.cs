using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	private AnimationState _state;
	private bool _isAttacking;
	public bool IsAttacking {
		get { 
			return _isAttacking;
		} set { 
			_isAttacking = value;
		}
	}

	private float _coolDown = 1.0f;
	private float _curTime;
	private bool _isCooledDown = false;

	private void Start() {
		_state = GetComponent<AnimationState> ();
	}

	private void Update() {
		_curTime += Time.deltaTime;
		if (_curTime > _coolDown) {
			_isCooledDown = true;
		} else {
			_isCooledDown = false;
		}
	} 

	public void Attack () {
		if (_isCooledDown) {
			StartCoroutine (Attacking ());
			_curTime = 0f;
		}
	}

	private IEnumerator Attacking() {
		UpdateCollider uc = GetComponent<UpdateCollider> ();
		uc.UpdateColl = true;
		_isAttacking = true;
		_state.SetState (States.Attack);
		yield return new WaitForSeconds(_state.GetAnimationDuration (AnimationState._attackAnim));
		uc.UpdateColl = false;
		_isAttacking = false;
	}
}
