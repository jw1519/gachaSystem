using UnityEngine;

public class OnFinish : StateMachineBehaviour
{
    [SerializeField] string animation;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<CharacterAnimationContoller>().ChangeAnimation(animation, 0.2f, stateInfo.length);
    }
}
