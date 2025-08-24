using System.Collections;
using UnityEngine;

public class CharacterAnimationContoller : MonoBehaviour
{
    Animator animator;
    public string currentAnimation = "";
    public bool isAttacking = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void ChangeAnimation(string animation, float crossFade = 0.2f, float time = 0) // can spam attack and charataracter freaks out
    {
        if (time > 0) //time is how long the animation lasts
            StartCoroutine(Wait());
        else
            Validate();

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(time);
            Validate();
            isAttacking = false;
        }
        void Validate()
        {
            if (currentAnimation != animation)
            {
                currentAnimation = animation;
                animator.CrossFade(animation, crossFade);
            }
        }
    }
    public void CheckMovementAnimation(Vector3 forceDirection, int movementSpeed)
    {
        if (isAttacking) return;
        if (forceDirection.z == movementSpeed)
        {
            ChangeAnimation("HumanM@Walk01_Forward [RM]");
        }
        else if (forceDirection.z == -movementSpeed)
        {
            ChangeAnimation("HumanM@Walk01_Backward [RM]");
        }
        else if (forceDirection.x == movementSpeed)
        {
            ChangeAnimation("HumanM@Walk01_Right [RM]");
        }
        else if (forceDirection.x == -movementSpeed)
        {
            ChangeAnimation("HumanM@Walk01_Left [RM]");
        }
        else
        {
            ChangeAnimation("HumanM@Idle01");
        }
    }
}
