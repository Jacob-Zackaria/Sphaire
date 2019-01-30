using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
//Variables.
	private Rigidbody rb;
	private SphereCollider col;
	private AudioSource jumpAudio;
	private AudioSource jumpLandAudio;

	private AudioSource[] jaudio;
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

//Initialising Components.
	void Start () {
		rb = GetComponent<Rigidbody> ();
		col = GetComponent<SphereCollider> ();

		jaudio = GetComponents<AudioSource> ();
		jumpAudio = jaudio[0];
		jumpLandAudio = jaudio[1];
	}

//Player Movement with Joystick.
	void FixedUpdate() {
		moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);
		moveVector = RotateWithView();
		if(moveVector != Vector3.zero)
		{
			rb.AddForce(moveVector * moveSpeed);
		} 
	}

//Jump Function.
	public void JumpVertical() {
		if(OnGround()) {
			jumpAudio.Play();
			rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
		}
	}

//Checking if player is on ground.
	private bool OnGround() {
		return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), 
		                            col.radius * .9f, groundLayers);
	}

//Rotate Player movement with Camera View.
	private Vector3 RotateWithView() {
		Vector3 dir = camTransform.TransformDirection(moveVector);
		dir.Set(dir.x, 0, dir.z);
		return (dir.normalized * moveVector.magnitude);
	}

//Saving new Checkpoint.
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Respawn"))
		{
			newCheckpoint.ChangeCheckpoint(other.transform.position);
		}
	}

//Jump and Landing Audio.
	private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 4f)
            jumpLandAudio.Play();
    }

}
