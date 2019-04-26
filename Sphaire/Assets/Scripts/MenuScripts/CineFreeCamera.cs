using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineFreeCamera : MonoBehaviour {

	private CinemachineFreeLook freeLookCam;
	public float sensitivityX = 5.0f;
    public float sensitivityY = 0.01f;
	public Joystick joystick;

    private int invertX = 1;
    private int invertY = 1;

    void Start () {
		freeLookCam = GetComponent<CinemachineFreeLook>();
	}
	
    //Update camera with joystick.
	void Update () {
		freeLookCam.m_XAxis.Value += (joystick.Horizontal * sensitivityX * invertX);
		freeLookCam.m_YAxis.Value += (joystick.Vertical * sensitivityY * invertY);
	}

    //Invert X Axis.
    public void InvertXAxis()
    {
        invertX *= -1;
    }

    //Invert Y Axis.
    public void InvertYAxis()
    {
        invertY *= -1;
    }

    //Adjust Sensitivity X Axis.
    public void SensitivityXAxis(float sensitivityXaxis)
    {
        sensitivityX = sensitivityXaxis;
    }

    //Adjust Sensitivity Y Axis.
    public void SensitivityYAxis(float sensitivityYaxis)
    {
        sensitivityY = sensitivityYaxis;
    }
}
