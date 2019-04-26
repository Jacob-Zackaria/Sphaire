using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
//Variables.
	private Rigidbody _rb;
	private SphereCollider _col;
	private AudioSource _jumpAudio;
	private AudioSource _jumpLandAudio;
	private float _knockBackCounter;
	private AudioSource[] _jaudio;
	private Vector3 _moveVector;
	private float _Horizontal;
	private float _Vertical;

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
		_rb = GetComponent<Rigidbody> ();
	}
//Initialising Components.
	void Start () {
		_col = GetComponent<SphereCollider> ();

		_jaudio = GetComponents<AudioSource> ();
		_jumpAudio = _jaudio[0];
		_jumpLandAudio = _jaudio[1];
	}

//Player Movement with Joystick.
	void FixedUpdate() {
		if(_knockBackCounter <= 0)
		{
			//To be changed.
			//moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);
			_Horizontal = Input.GetAxis("Horizontal");
			_Vertical = Input.GetAxis("Vertical");
			_moveVector = new Vector3(_Horizontal, 0f, _Vertical); 
			_moveVector = RotateWithView();
			if(_moveVector != Vector3.zero)
			{
				_rb.AddForce(_moveVector * moveSpeed);
			}
			if(Input.GetAxis("Jump") > 0)
			{
				JumpVertical();
			} 
		} 
		else
		{
			_knockBackCounter -= Time.deltaTime;
		}
	}

//Jump Function.
	public void JumpVertical() {
		if(OnGround()) {
			_jumpAudio.Play();
			_rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
		}
	}

//Checking if player is on ground.
	private bool OnGround() {
		return Physics.CheckCapsule(_col.bounds.center, new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z), 
		                            _col.radius * .9f, groundLayers);
	}

//Rotate Player movement with Camera View.
	private Vector3 RotateWithView() {
		Vector3 dir = camTransform.TransformDirection(_moveVector);
		dir.Set(dir.x, 0, dir.z);
		return (dir.normalized * _moveVector.magnitude);
	}

//Disable movements when player is disabled.
	private void OnDisable() {
		_rb.isKinematic = true;
	}

//Enable movements when player is enabled.
	private void OnEnable() {
		_rb.isKinematic = false;
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
            _jumpLandAudio.Play();
    }

//Knockback Player on taking Damage.
	public void Knockback(Vector3 direction)
	{
		_knockBackCounter = knockBackTime;

		_rb.AddForce(direction * knockBackForce);
	}

}
