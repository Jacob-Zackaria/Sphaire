using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesLoader : StateMachineBehaviour
{
    [HideInInspector]
    public int sceneIndex;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<FadeComplete>().LoadScene(sceneIndex);
    }
}
