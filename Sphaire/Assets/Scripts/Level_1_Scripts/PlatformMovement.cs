using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Vector3 moveDirection;
    public float moveSpeed;

    private void Update() {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
