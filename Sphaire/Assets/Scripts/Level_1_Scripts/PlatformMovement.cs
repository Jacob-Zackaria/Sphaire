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

    public Vector3 endPosition;

    [Range(0, 2)]
    public float moveSpeed;
    public float waitTime = 2f;

    private Vector3 _finalPosition;
    private float _distance;
    private float _delayPlatform = 0f;
    private bool _isArrived;

    //Calculate final position.
    private void Start()
    {
        _finalPosition = transform.position + endPosition;
    }

    private void FixedUpdate() {

        //Calculate distance to final position.
        _distance = Vector3.Distance(transform.position, _finalPosition);

        //If script is active and no delay time, move.
        if (isActive && _delayPlatform <= 0f)
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

        //Update delay time.
        if(_delayPlatform > 0f)
        {
            _delayPlatform -= Time.deltaTime;
        }
    }

    //One shot platform movement.
    private void OneShot()
    {
        if (_distance > 0.1f)
        {
            transform.Translate(endPosition.normalized * moveSpeed * Time.deltaTime);
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
            transform.Translate(endPosition.normalized * moveSpeed * Time.deltaTime);
        }
        else
        {
            endPosition *= -1;
            _finalPosition = transform.position + endPosition;
            _delayPlatform = waitTime;
        }
    }

    //Ping Pong movement.
    private void PingPong()
    {
        if (_distance > 0.1f)
        {
            OneShot();
        }
        else if (_isArrived == true)
        {
            isActive = false;
            _isArrived = false;
        }
        else
        { 
            Loop();
            _isArrived = true;
        }
    }
}
