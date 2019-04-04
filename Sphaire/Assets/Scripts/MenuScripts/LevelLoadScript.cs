using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadScript : MonoBehaviour {	
	public Animator animator;
	public int sceneNumber;

	private ScenesLoader sceneLoader;

	private void Start() {
		sceneLoader = animator.GetBehaviour<ScenesLoader>();
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			Vibration.Vibrate(1500);
			LoadSceneFunction();
		}
	}

	public void LoadSceneFunction()
	{
		sceneLoader.sceneIndex = sceneNumber;
		animator.SetTrigger("Fade_Out_Trigger");
	}

	
}
