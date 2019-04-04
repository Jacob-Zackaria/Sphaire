using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttackControl : StateMachineBehaviour
{
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        animator.SetInteger("AttackMode", Random.Range(0, 3));
    }
}
