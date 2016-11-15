using UnityEngine;
using System.Collections;

public class CameraBounds : MonoBehaviour {
	private Camera _cam;

	private void Start () {
		_cam = Camera.main;
	}


	/// <summary>
	/// Gets the camera boundrey.<c>
	/// object.max.y = top boundrey;
	/// object.min.y = bottom boundrey;
	/// object.max.x = right boundrey;
	/// object.min.x = left boundrey;
	/// </summary>
	/// <returns>Boundreys of the camera</returns>
	public Bounds GetBounds() {
		float height = 2 * _cam.orthographicSize;
		float width = height * _cam.aspect;

		Bounds boundrey = new Bounds (_cam.transform.position, new Vector2(width, height));
		return boundrey;
	}

	public bool OutOfCameraBound(GameObject obj) {
		Vector2 pos = obj.transform.position;
		Bounds boundrey = GetBounds ();
//		Debug.Log (GetBounds ().max.x);
		if (pos.x < boundrey.min.x || pos.x > boundrey.max.x ||
		   pos.y < boundrey.min.y) {
			return true;
		} 
		return false;
	}
}
