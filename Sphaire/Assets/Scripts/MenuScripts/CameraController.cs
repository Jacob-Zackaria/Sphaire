using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform playerTransform;
    public Joystick joystick;

    private Vector3 offset;
	private Quaternion rotation;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 3.0f;
    private float sensitivityY = 0.5f;

    private void Update() {
        currentX += joystick.Horizontal * sensitivityX;    
        currentY += joystick.Vertical * sensitivityY;
    }

    void LateUpdate ()
    {
		offset = new Vector3 (0, 0.74f, 1.5f);
        rotation = Quaternion.Euler (currentY, currentX, 0);
		transform.position = playerTransform.position + (rotation * offset);
        transform.LookAt(playerTransform);
    }
}