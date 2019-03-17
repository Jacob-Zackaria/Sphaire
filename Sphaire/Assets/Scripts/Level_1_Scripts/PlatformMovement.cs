using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Vector3 moveDirection;
    public Vector3 moveSpeed;

    private void Update() {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
