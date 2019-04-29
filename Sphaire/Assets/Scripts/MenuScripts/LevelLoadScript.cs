using UnityEngine;

public class LevelLoadScript : MonoBehaviour {	
	public Animator animator;
	public string sceneName;

	private ScenesLoader sceneLoader;

	private void Start() {
		sceneLoader = animator.GetBehaviour<ScenesLoader>();
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
            Handheld.Vibrate();
			LoadSceneFunction();
		}
	}

	public void LoadSceneFunction()
	{
		sceneLoader.sceneName = sceneName;
		animator.SetTrigger("Fade_Out_Trigger");
	}

	
}
