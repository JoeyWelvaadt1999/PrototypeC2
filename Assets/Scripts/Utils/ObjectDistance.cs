using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ObjectDistance : MonoBehaviour {
	[SerializeField]private Transform _objectA;
	[SerializeField]private Transform _objectB;

	private void Update() {
		CalculateDistance ();
	}

	private void CalculateDistance() {
		Vector2 va = _objectA.position;
		Vector2 vb = _objectB.position;
		float dis = (vb - va).magnitude;
	}
}
