using UnityEngine;
using System.Collections;
using Spine.Unity;

public class Destructable : MonoBehaviour, IDestructable {
	[SerializeField]private AudioClip _ac;
	private string _destructAnim = "BreakableWallDESTROY";
	private CameraShake _cs;
	private PlayerDeath _pd;

	private SkeletonAnimation _anim;

	private void Start() {
		_cs = FindObjectOfType<CameraShake> ();
		_pd = FindObjectOfType<PlayerDeath> ();
		_anim = GetComponent<SkeletonAnimation> ();
	}



	public Vector2 GetPosition() {
		return transform.position;
	}

	private void OnCollisionEnter2D(Collision2D coll) {
		PlayerAttack pa = coll.gameObject.GetComponent<PlayerAttack> ();

		if (pa.IsAttacking) {
			pa.IsAttacking = false;
			_cs.InitShake ();
			GetComponent<BoxCollider2D> ().enabled = false;
			_anim.state.SetAnimation (0, _destructAnim, false);
			GetComponent<AudioSource> ().PlayOneShot (_ac);
			StartCoroutine (DestroyObject ());
		} else {
			_pd.Die(true);
		}

	}

	private IEnumerator DestroyObject() {
		
		yield return new WaitForSeconds (_anim.AnimationState.GetCurrent(0).animation.Duration);
		Destroy (this.gameObject);
	}
}
