using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public enum MoveMode
    {
        oneShot,
        loop,
        pingPong
    }

    public bool isActive;
    public MoveMode moveMode;

    public Vector3 moveDirection;
    public float moveSpeed;
    public float waitTime;

    private Vector3 _finalPosition;
    private float _distance;

    /*public Sound[] sounds;
    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject); 
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
        }
    }*/

    private void Start()
    {
        _finalPosition = transform.position + moveDirection;
        _distance = Vector3.Distance(transform.position, _finalPosition);
    }

    private void Update() {
        if (isActive)
        {
            switch (moveMode)
            {
                case MoveMode.oneShot:
                    OneShot();
                    break;
                case MoveMode.loop:
                    Loop();
                    break;
                case MoveMode.pingPong:
                    PingPong();
                    break;
            }
        }
    }

    //One shot platform movement.
    private void OneShot()
    {
        if (_distance > 0.1f)
        {
            transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
            _distance = Vector3.Distance(transform.position, _finalPosition);
        }
        else
        {
            isActive = false;
        }
    }

    //Looping platform movement.
    private void Loop()
    {
        if (_distance > 0.1f)
        {
            transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
            _distance = Vector3.Distance(transform.position, _finalPosition);
        }
        else
        {
            moveDirection *= -1;
            _finalPosition = transform.position + moveDirection;
            _distance = Vector3.Distance(transform.position, _finalPosition);
        }
    }

    //Ping Pong movement.
    private void PingPong()
    {

    }
}
