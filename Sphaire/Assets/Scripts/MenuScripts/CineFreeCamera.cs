using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineFreeCamera : MonoBehaviour {

	private CinemachineFreeLook freeLookCam;
	private float sensitivityX = 3.0f;
    private float sensitivityY = 0.01f;
	public Joystick joystick;

	void Start () {
		freeLookCam = GetComponent<CinemachineFreeLook>();
	}
	
	void Update () {
		freeLookCam.m_XAxis.Value += (joystick.Horizontal * sensitivityX);
		freeLookCam.m_YAxis.Value += (joystick.Vertical * sensitivityY);
	}
}
