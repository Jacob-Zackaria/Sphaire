using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoDisplay : MonoBehaviour {
	public GameObject infoObject;
    public GameObject gameView;

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			Handheld.Vibrate();
            gameView.SetActive(false);
			
			infoObject.SetActive(true);

		}
	}

}
