using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
	[Range(0,10)][SerializeField]private float _magnitude;

	public void InitShake() {
		StartCoroutine (Shake ());
	}

	private IEnumerator Shake() {
		for (int i = 0; i < 3; i++) {
			Vector3 tpos = transform.position;
			tpos.x += Random.insideUnitCircle.x * _magnitude;
			tpos.y +=  Random.insideUnitCircle.y * _magnitude;
			tpos.z = transform.position.z;
			transform.position = tpos;

			yield return new WaitForSeconds (0.1f);
		}
		transform.position = new Vector3(transform.position.x, 0, transform.position.z);
	}
}
