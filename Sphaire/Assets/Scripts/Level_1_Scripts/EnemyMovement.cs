using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    const float animationSmoothTime = 0.1f;

    NavMeshAgent agent;
    Animator animator;

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

        //Enemy left and right movement animation control.
        float rotationPercent = agent.angularSpeed / 1f; 
        animator.SetFloat("Strafing", rotationPercent, animationSmoothTime, Time.deltaTime);
    }
}
