using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
//Variables.
	private Rigidbody rb;
	private SphereCollider col;
	private AudioSource jumpAudio;
	private AudioSource jumpLandAudio;
	private float knockBackCounter;
	private AudioSource[] jaudio;
	private Vector3 moveVector;
	private float Horizontal;
	private float Vertical;

	public PlayerDeath newCheckpoint;
	public float knockBackTime;
	public float knockBackForce;

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

//Called when game starts.
	private void Awake() {
		rb = GetComponent<Rigidbody> ();
	}
//Initialising Components.
	void Start () {
		col = GetComponent<SphereCollider> ();

		jaudio = GetComponents<AudioSource> ();
		jumpAudio = jaudio[0];
		jumpLandAudio = jaudio[1];
	}

//Player Movement with Joystick.
	void FixedUpdate() {
		if(knockBackCounter <= 0)
		{
			//To be changed.
			//moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);
			Horizontal = Input.GetAxis("Horizontal");
			Vertical = Input.GetAxis("Vertical");
			moveVector = new Vector3(Horizontal, 0f, Vertical); 
			moveVector = RotateWithView();
			if(moveVector != Vector3.zero)
			{
				rb.AddForce(moveVector * moveSpeed);
			}
			if(Input.GetAxis("Jump") > 0)
			{
				JumpVertical();
			} 
		} 
		else
		{
			knockBackCounter -= Time.deltaTime;
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

//Disable movements when player is disabled.
	private void OnDisable() {
		rb.isKinematic = true;
	}

//Enable movements when player is enabled.
	private void OnEnable() {
		rb.isKinematic = false;
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

//Knockback Player on taking Damage.
	public void Knockback(Vector3 direction)
	{
		knockBackCounter = knockBackTime;

		rb.AddForce(direction * knockBackForce);
	}

}
