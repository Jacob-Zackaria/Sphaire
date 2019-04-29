using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class OptionsMenu : MonoBehaviour {

	public AudioMixer mainMixer;
	public AudioMixer sfxMixer;
    public Slider mainVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider camJoystickXSpeed;
    public Slider camJoystickYSpeed;
    public Dropdown graphicsDropdown;
    public Toggle invertXToggle;
    public Toggle invertYToggle;


    //Load Option settings.
    private void Awake()
    {
        if (mainVolumeSlider != null)
            mainVolumeSlider.value = PlayerPrefs.GetFloat("MainVolume");
        if (sfxVolumeSlider != null)
            sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        if (camJoystickXSpeed != null)
            camJoystickXSpeed.value = PlayerPrefs.GetFloat("CamStickXSpeed");
        if (camJoystickYSpeed != null)
            camJoystickYSpeed.value = PlayerPrefs.GetFloat("CamStickYSpeed");

        if (graphicsDropdown != null)
        {
            graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality");
            QualitySettings.SetQualityLevel(graphicsDropdown.value);
        }
        if (invertXToggle != null)
            invertXToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("InvertX"));
        if (invertYToggle != null)
            invertYToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("InvertY"));
    }

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

    //Pause game from running.
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    //Resume game from pause.
    public void Resume()
    {
        Time.timeScale = 1f;
    }

    //Save option settings.
    public void SaveOption()
    {
        if(mainVolumeSlider != null)
            PlayerPrefs.SetFloat("MainVolume", mainVolumeSlider.value);
        if (sfxVolumeSlider != null)
            PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
        if (camJoystickXSpeed != null)
            PlayerPrefs.SetFloat("CamStickXSpeed", camJoystickXSpeed.value);
        if (camJoystickYSpeed != null)
            PlayerPrefs.SetFloat("CamStickYSpeed", camJoystickYSpeed.value);

        if (graphicsDropdown != null)
            PlayerPrefs.SetInt("GraphicsQuality", graphicsDropdown.value);
        if (invertXToggle != null)
            PlayerPrefs.SetInt("InvertX", (invertXToggle.isOn ? 1 : 0));
        if (invertYToggle != null)
            PlayerPrefs.SetInt("InvertY", (invertYToggle.isOn ? 1 : 0));      
    }


}
