using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private SphereCollider col;
	private Vector3 moveVector;
	public PlayerDeath newCheckpoint;

	[Tooltip("Input player joystick")]
	public Joystick joystick;
	[Tooltip("Input Camera Transform")]
	public Transform camTransform;
	[Tooltip("Layers where player can jump")]
	public LayerMask groundLayers;

	[Space]
	[Header("Settings")]
	[Range(0f,10f)]
	public float jumpVelocity = 10f;
	[Range(0f,10f)]
	public float moveSpeed = 10f;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		col = GetComponent<SphereCollider> ();
	}


	void FixedUpdate() {
		moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);
		moveVector = RotateWithView();
		if(moveVector != Vector3.zero)
		{
			rb.AddForce(moveVector * moveSpeed);
		} 
	}

	public void JumpVertical() {
		if(OnGround()) {
			rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
		}
	}

	private bool OnGround() {
		return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), 
		                            col.radius * .9f, groundLayers);
	}

	private Vector3 RotateWithView() {
		Vector3 dir = camTransform.TransformDirection(moveVector);
		dir.Set(dir.x, 0, dir.z);
		return (dir.normalized * moveVector.magnitude);
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Respawn"))
		{
			newCheckpoint.ChangeCheckpoint(other.transform.position);
		}
	}

}
