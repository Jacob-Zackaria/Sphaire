using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillScript : MonoBehaviour {

	private AudioSource audioSource;
	public GameObject audioObject;
	private AudioSource audioMain;
	private bool ended;
	private float count;
	private bool single;

	void Start () {
		ended = false;
		count = 0.0f;
		single = false;
		audioSource = GetComponent<AudioSource>();
		audioMain = audioObject.GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player") && ended == false && single == false) {
			audioMain.Pause();
			audioSource.Play();
			ended = true;
			single = true;
		}	
	}
	
	void Update () {
		if(!audioSource.isPlaying && ended == true && single == true) {
			audioMain.volume = 0;
			audioMain.Play();
			single = false;
		}

		if(!audioSource.isPlaying && ended == true) {
			if(count > 5) {
				count = 0.0f;
				ended = false;
			}
			count += Time.deltaTime*0.1f;
		}

		if(!audioSource.isPlaying && audioMain.volume < 1) {
			audioMain.volume += Time.deltaTime;
		}
	}
}