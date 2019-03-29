using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    const float animationSmoothTime = 0.1f;
    bool isRight;

    NavMeshAgent agent;
    Animator animator;
    Transform target;
    Patroller patroller;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();    
    }

    void Update()
    {
        //Enemy forward and backward movememnt animation control.
        float speedPercent = agent.velocity.magnitude / agent.speed; 
        animator.SetFloat("Speed", speedPercent, animationSmoothTime, Time.deltaTime);


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

        rotationPercent = 

        //Enemy left and right movement animation control.
        animator.SetFloat("Strafing", rotationPercent, animationSmoothTime, Time.deltaTime);

        /* // Rotate towards player
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, rotationSpeed * Time.deltaTime); */
        
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
}
