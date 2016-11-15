using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	[SerializeField]private GameObject _object;
	private void Update () {
		if (Camera.main.transform.position.x + Camera.main.pixelWidth / 100f < 205.7f) {
			transform.position = Vector3.Lerp (Camera.main.transform.position, new Vector3 (_object.transform.position.x + (Camera.main.orthographicSize * 2) * Camera.main.aspect * 0.25f, Camera.main.transform.position.y, Camera.main.transform.position.z), 0.1f);
		}
	}
}
