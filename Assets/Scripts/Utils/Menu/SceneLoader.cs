using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {
	[SerializeField]private SpriteRenderer _background;
	[SerializeField]private Text _text;
	[SerializeField]private GameObject _menu;
	private bool _loadScene;

	public void LoadScene(int scene) {
		StartCoroutine (LoadSceneAsync(scene));
		_background.color = new Color (0, 0, 0, 1);
		_text.text = "Loading...";
		_loadScene = true;
		_menu.SetActive (false);
	}

	private void Update() {
		if (_loadScene) {
			_text.color = new Color (_text.color.r, _text.color.g, _text.color.b, Mathf.PingPong (Time.time, 1));
		}
	}

	private IEnumerator LoadSceneAsync(int scene) {
		yield return new WaitForSeconds (5f);
		AsyncOperation sync = SceneManager.LoadSceneAsync (scene);

		while (!sync.isDone) {
			yield return null;
		}
	}
}
