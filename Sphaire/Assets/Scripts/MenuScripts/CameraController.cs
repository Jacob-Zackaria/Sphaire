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

    [Header("Collision Variables")]

    [Header("Transparency")]
    public bool changeTransparency = true;
    public MeshRenderer targetRenderer;

    [Header("Speeds")]
    public float moveSpeed = 5f;
    public float returnSpeed = 9f;
    public float wallPush = 0.7f;

    [Header("Distances")]
    public float closestDistanceToPlayer = 2f;
    public float evenCloserDistanceToPlayer = 1f;

    [Header("Mask")]
    public LayerMask collisionMask;

    private bool pitchLock = false;
 
    private void Update() {
        currentX += joystick.Horizontal * sensitivityX;    
        currentY += joystick.Vertical * sensitivityY;
    }

    void LateUpdate ()
    {
		offset = new Vector3 (0, 0.74f, 1.5f);

		if(!pitchLock) {
        	rotation = Quaternion.Euler (currentY, currentX, 0);
		}
		else {
			rotation = Quaternion.Euler (0, currentX, 0);
		}

		CollisionCheck(playerTransform.position + (rotation * offset));
		WallCheck ();

		transform.position = playerTransform.position + (rotation * offset);
        transform.LookAt(playerTransform);
    }

    private void WallCheck() {

		Ray ray = new Ray (playerTransform.position, -playerTransform.forward);
		RaycastHit hit;

		if (Physics.SphereCast (ray, 0.2f, out hit, 0.7f, collisionMask)) {
			pitchLock = true;
		} else {
			pitchLock = false;
		}

	}

    private void CollisionCheck (Vector3 retPoint) {

		RaycastHit hit;

		if (Physics.Linecast (playerTransform.position, retPoint, out hit, collisionMask)) { 

			Vector3 norm = hit.normal * wallPush;
			Vector3 p = hit.point + norm;

			TransparencyCheck ();

			if (Vector3.Distance (Vector3.Lerp (transform.position, p, moveSpeed * Time.deltaTime), playerTransform.position) <= evenCloserDistanceToPlayer) {


			} else {
				transform.position = Vector3.Lerp (transform.position, p, moveSpeed * Time.deltaTime);
			}

			return;

		}


		FullTransparency ();

		transform.position = Vector3.Lerp (transform.position, retPoint, returnSpeed * Time.deltaTime);
		pitchLock = false;


	}

    private void TransparencyCheck() {

		if (changeTransparency) {
			
			if (Vector3.Distance (transform.position, playerTransform.position) <= closestDistanceToPlayer) {
				
				Color temp = targetRenderer.sharedMaterial.color;
				temp.a = Mathf.Lerp (temp.a, 0.2f, moveSpeed * Time.deltaTime);

				targetRenderer.sharedMaterial.color = temp;


			} else {

				if (targetRenderer.sharedMaterial.color.a <= 0.99f) {

					Color temp = targetRenderer.sharedMaterial.color;
					temp.a = Mathf.Lerp (temp.a, 1, moveSpeed * Time.deltaTime);

					targetRenderer.sharedMaterial.color = temp;

				}

			}

		}

	}

    private void FullTransparency() {
		if (changeTransparency) {
			if (targetRenderer.sharedMaterial.color.a <= 0.99f) {

				Color temp = targetRenderer.sharedMaterial.color;
				temp.a = Mathf.Lerp (temp.a, 1, moveSpeed * Time.deltaTime);

				targetRenderer.sharedMaterial.color = temp;

			}
		}
	}
}