using UnityEngine;

public class DayChange : MonoBehaviour
{
    public GameObject Sun;

    private float speed = 2f;

    void Update()
    {
        Sun.transform.rotation = Quaternion.Euler((Time.time * speed) % 360f, 0.0f, 0.0f);
    }
}
