using UnityEngine;
using System.Collections;
using Spine.Unity;
using UnityEngine.UI;
public class GameOverMenu : MonoBehaviour {
	[SerializeField]private GameObject _menu;
	private GameObject _innerMenu;
	private PlayerDeath _pd;

	private bool _isOpen = false;

	private void Start () {
		_pd = FindObjectOfType<PlayerDeath> ();
	}

	private void Update() {
		if (_pd.IsDeath) {
			_menu.transform.position = new Vector3 (Camera.main.transform.position.x, 1.44f, _menu.transform.position.z);
			if (!_isOpen) {
				OpenMenu ();
			}
		}
	} 

	private void OpenMenu() {
		_isOpen = true;
//		GameObject go = Instantiate(_menu, new Vector3 (Camera.main.transform.position.x, 0, _menu.transform.position.z), Quaternion.identity) as GameObject;
		_menu.transform.position = new Vector3 (Camera.main.transform.position.x, 1.44f, _menu.transform.position.z);
		SkeletonAnimation _anim = _menu.GetComponent<SkeletonAnimation> ();
		_anim.state.SetAnimation (0, "MenuOpen", false);

		StartCoroutine (AddMenu (_anim, _menu));
	}

	public void LoadScene(int scene) {
		StartCoroutine(LoadSceneAsync (scene));
	}


	private IEnumerator LoadSceneAsync(int scene) {
		AsyncOperation sync = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (scene);

		while (!sync.isDone) {
			yield return null;
		}
	}
		

	private IEnumerator AddMenu(SkeletonAnimation skeleton, GameObject go) {
		yield return new WaitForSeconds (skeleton.SkeletonDataAsset.GetSkeletonData (true).FindAnimation (skeleton.AnimationName).duration);
		Debug.Log ("lol");
		_innerMenu = go.transform.FindChild ("Canvas").gameObject;
		_innerMenu.SetActive (true);
	}
}
