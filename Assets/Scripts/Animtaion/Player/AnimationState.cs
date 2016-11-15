using UnityEngine;
using System.Collections;
using Spine.Unity;

public enum States 
{
	Attack,
	Running,
	Falling,
	Jumping,
	Idling,
	Die
}

public class AnimationState : MonoBehaviour {
	private States _state = States.Idling;
	public States State {
		get { 
			return _state;
		}
	}
	private SkeletonAnimation _skeleton;
	public const string _fallingAnim = "Fall";
	public const string _jumpAnim = "Jump";
	public const string _runAnim = "Runn";
	public const string _attackAnim = "Hit";

	private void Start () {
		_skeleton = GetComponent<SkeletonAnimation> ();
	}

	public void SetState(States state) {
		_state = state;
		switch (state) {
		case States.Falling:
			if (_skeleton.AnimationName != _attackAnim) {
				_skeleton.state.SetAnimation (0, _fallingAnim, true);
			}
			break;
		case States.Jumping:
			if (_skeleton.AnimationName != _attackAnim) {
				_skeleton.state.SetAnimation (0, _jumpAnim, true);
			}
			break;
		case States.Running:
			if (_skeleton.AnimationName != _attackAnim && _skeleton.AnimationName != _runAnim) {
				_skeleton.state.SetAnimation (0, _runAnim, true);
			}
			break;
		case States.Attack:
			_skeleton.state.SetAnimation (0, _attackAnim, false);
//			_skeleton.state.AddAnimation (0, _runAnim, true, _skeleton.SkeletonDataAsset.GetSkeletonData(true).FindAnimation(_attackAnim).duration);
			break;
		case States.Die:
			_skeleton.state.SetAnimation (0, "Crash", false);
			_skeleton.state.AddAnimation (0, "death_fall", false, GetAnimationDuration ("Crash"));
			_skeleton.state.AddAnimation (0, "death", false, GetAnimationDuration ("death_fall") + GetAnimationDuration ("Crash"));
			break;
		default:
			break;
		}
	}


	public float GetAnimationDuration(string animName) {
		return _skeleton.SkeletonDataAsset.GetSkeletonData (true).FindAnimation (animName).duration;
	}
}
