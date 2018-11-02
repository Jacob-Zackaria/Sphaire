using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public Joystick joystick;

    private Vector3 offset;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 3.0f;
    private float sensitivityY = 1.0f;

    void Start ()
    {
        offset = transform.position - player.transform.position;
    }

    private void Update() {
        currentX += joystick.Horizontal * sensitivityX;    
        currentY += joystick.Vertical * sensitivityY;
    }

    void LateUpdate ()
    {
        Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);
        transform.position = player.transform.position + (rotation * offset);
    }
}