﻿using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

	public AudioMixer mainMixer;
	public AudioMixer sfxMixer;

	//Main Volume control.
	public void VolumeControlMain(float volume) {
		mainMixer.SetFloat("masterVolume", volume);
	}

	//SFX Volume control.
	public void VolumeControlSFX(float volume) {
		sfxMixer.SetFloat("sfxVolume", volume);
	}

	//Set Game Graphics.
	public void SetQuality(int qualityIndex) {
		QualitySettings.SetQualityLevel(qualityIndex);
	}

}
