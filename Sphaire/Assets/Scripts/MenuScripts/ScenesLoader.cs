using UnityEngine;

public class ScenesLoader : StateMachineBehaviour
{
    [HideInInspector]
    public string sceneName;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<FadeComplete>().LoadScene(sceneName);
    }
}
