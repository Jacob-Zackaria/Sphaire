using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoDisplay : MonoBehaviour {
	public GameObject infoObject;
	public GameObject pauseObject;
	public GameObject playerJoystick;
	public GameObject cameraJoystick;
	public GameObject jumpButton;

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			Handheld.Vibrate();
			pauseObject.SetActive(false);

			playerJoystick.SetActive(false);
			cameraJoystick.SetActive(false);
			jumpButton.SetActive(false);
			
			infoObject.SetActive(true);

		}
	}

}
