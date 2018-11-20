using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadScript : MonoBehaviour {	
	public Animator animator;

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			Vibration.Vibrate();
			animator.SetTrigger("Fade_Out_Trigger");
		}
	}

	
}
