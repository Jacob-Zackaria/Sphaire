using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadScript : MonoBehaviour {	
	public Animator animator;
	public ScenesLoader sceneLoader;
	public int sceneNumber;

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
