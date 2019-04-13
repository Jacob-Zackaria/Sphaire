using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    const float animationSmoothTime = 0.1f;
    bool isRight;
    float rotationPercent;
    private float _attackStartTime = 2f;

    public float rotationSpeed = 1f;
    public float rotationSmoothness = 2f;
    [Tooltip("Minimum 4 and Maximum 10")]
    [Range(4, 10)]
    public float attackWaitTime = 6f;

    NavMeshAgent agent;
    Animator animator;
    Transform target;
    Patroller patroller;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();  
        patroller = GetComponent<Patroller>();
    }

    void Update()
    {
        //Enemy forward and backward movememnt animation control.
        float speedPercent = agent.velocity.magnitude / agent.speed; 
        animator.SetFloat("Speed", speedPercent, animationSmoothTime, Time.deltaTime);

        //Target selection.
        if(patroller.insideEnemyRadius())
        {
            target = patroller.target;
        }
        else
        {
            target = patroller.destTransform;
        }

        Quaternion lookDirection = Quaternion.LookRotation(target.position - transform.position);
 
        // Get our Direction we are going to Rotate.
        isRight = GetRotateDirection(transform.rotation, lookDirection);

        if(isRight)
        {
            rotationPercent = Mathf.Lerp(0f, 1f, rotationSmoothness * Time.deltaTime);
        }
        else
        {
            rotationPercent = Mathf.Lerp(0f, -1f, rotationSmoothness * Time.deltaTime);
        } 

        //Enemy left and right movement animation control.
        animator.SetFloat("Strafing", rotationPercent, animationSmoothTime, Time.deltaTime);

        if(patroller.insideEnemyRadius())
        {
            // Rotate towards player
            transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, rotationSpeed * Time.deltaTime);

            //Attack player.
            if(patroller.arrived && _attackStartTime < 0)
            {
                Attack();
            }
        }

        //Timer controls.
        if(_attackStartTime > 0)
        {
            _attackStartTime -= Time.deltaTime;
        }
        
    }

    //Attacking Function.
    private void Attack()
    {
        animator.SetTrigger("Attack");
        _attackStartTime = attackWaitTime;
    }

    //Finds direction of rotaion, even if the enemy angle is 10 deg and rotated 
    //to left to 350 deg it still gives left direction.
    bool GetRotateDirection(Quaternion from, Quaternion to)
    {
        float fromY = from.eulerAngles.y;
        float toY  = to.eulerAngles.y;
        float clockWise = 0f;
        float counterClockWise = 0f;
        
        if (fromY <= toY)
        {
            clockWise = toY-fromY;
            counterClockWise = fromY + (360-toY);
        }
        else
        {
            clockWise = (360-fromY) + toY;
            counterClockWise = fromY-toY;
        }
        return (clockWise <= counterClockWise);
    }
}
