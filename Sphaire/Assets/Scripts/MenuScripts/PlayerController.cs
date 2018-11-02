using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;

	public Joystick joystick;
	public float moveSpeed = 10f;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);
		if(moveVector != Vector3.zero)
		{
			rb.AddForce(moveVector * -moveSpeed);
		}
	}

}
