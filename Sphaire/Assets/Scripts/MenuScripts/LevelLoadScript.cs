using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelLoadScript : MonoBehaviour {
	public int sceneIndex;
	public Animator animator;
	public Slider slider;
	public GameObject loadingScreen;

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			Handheld.Vibrate();
			StartCoroutine(LoadAsynchronously(sceneIndex));
		}
	}

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
