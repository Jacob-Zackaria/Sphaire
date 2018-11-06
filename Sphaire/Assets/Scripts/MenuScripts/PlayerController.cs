using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private Vector3 moveVector;

	public Joystick joystick;
	public float jumpVelocity = 10f;
	public Transform camTransform;
	public float moveSpeed = 10f;

	void Start () {
		rb = GetComponent<Rigidbody> ();
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
		rb.velocity = Vector3.up * jumpVelocity;
	}

	private Vector3 RotateWithView() {
		Vector3 dir = camTransform.TransformDirection(moveVector);
		dir.Set(dir.x, 0, dir.z);
		return (dir.normalized * moveVector.magnitude);
	}

}
