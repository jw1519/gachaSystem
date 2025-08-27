using UnityEngine;

public class OnFinish : StateMachineBehaviour
{
    [SerializeField] string animation;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<CharacterAnimationContoller>())
        {
            animator.GetComponent<CharacterAnimationContoller>().ChangeAnimation(animation, 0.2f, stateInfo.length);
        }
        else if (animator.GetComponent<EnemyAnimationController>())
        {
            animator.GetComponent<EnemyAnimationController>().ChangeAnimation(animation, 0.2f, stateInfo.length);
        }
    }
        
}
