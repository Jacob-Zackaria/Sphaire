using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FadeComplete : MonoBehaviour {
	public int sceneIndex;
	public Slider slider;
	public GameObject loadingScreen;
	/* public void LoadLevel() {
		StartCoroutine(LoadAsynchronously(sceneIndex));
	}*/

	IEnumerator LoadAsynchronously(int sceneIndex) {
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

		loadingScreen.SetActive(true);

		while(!operation.isDone) {
			float progress = Mathf.Clamp01(operation.progress/ 0.9f);
			slider.value = progress;
			yield return null;
		}
	}
}
