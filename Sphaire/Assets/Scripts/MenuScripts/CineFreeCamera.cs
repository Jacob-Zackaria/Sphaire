using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineFreeCamera : MonoBehaviour {

	private CinemachineFreeLook freeLookCam;
	public float sensitivityX = 5.0f;
    public float sensitivityY = 0.01f;
	public Joystick joystick;

	void Start () {
		freeLookCam = GetComponent<CinemachineFreeLook>();
	}
	
	void Update () {
		freeLookCam.m_XAxis.Value += (joystick.Horizontal * sensitivityX);
		freeLookCam.m_YAxis.Value += (joystick.Vertical * sensitivityY);
	}
}
