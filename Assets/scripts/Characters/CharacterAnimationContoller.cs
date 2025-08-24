using UnityEngine;

public class CharacterAnimationContoller : MonoBehaviour
{
    Animator animator;
    public string currentAnimation = "";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void ChangeAnimation(string animation, float crossFade = 0.2f)
    {
        if (currentAnimation != animation)
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossFade);
        }
    }
    public void CheckAnimation(Vector3 forceDirection, int movementSpeed)
    {
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
