using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsDisplay : MonoBehaviour {

	private AudioSource audioSource;
	public GameObject creditObject;
	public GameObject menuObject;
	public GameObject playerJoystick;
	public GameObject cameraJoystick;

	void Start() {
		audioSource = GetComponent<AudioSource>();
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			Handheld.Vibrate();
			audioSource.Stop();
			menuObject.SetActive(false);

			playerJoystick.SetActive(false);
			cameraJoystick.SetActive(false);
			
			creditObject.SetActive(true);

		}
	}

}
