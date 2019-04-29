using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FadeComplete : MonoBehaviour {
	[HideInInspector]
	public int sceneName;
	
	public Slider slider;
	public GameObject loadingScreen;

	public void LoadScene(string sceneName)
	{
		StartCoroutine(LoadAsynchronously(sceneName));
	}

	IEnumerator LoadAsynchronously(string sceneName) {
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

		loadingScreen.SetActive(true);

		while(!operation.isDone) {
			float progress = Mathf.Clamp01(operation.progress/ 0.9f);
			slider.value = progress;
			yield return null;
		}
	}
}
