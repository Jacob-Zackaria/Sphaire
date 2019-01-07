using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private SphereCollider col;
	private Vector3 moveVector;

	public Joystick joystick;
	public Transform camTransform;
	public LayerMask groundLayers;

	[Header("Settings")]
	public float jumpVelocity = 10f;
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

}
