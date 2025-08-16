using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour, IJump
{
    InputSystem_Actions playerInputActions;
    InputAction move;

    [Header("movement")]
    public Rigidbody rb;
    public int movementSpeed;
    public int jumpPower;
    Vector3 forceDirection = Vector3.zero;
    [SerializeField] Camera cam;
    

    [Header("animation")]
    Animator animator;
    public string currentAnimation = "";

    [Header("GroundCheck")]
    public Transform GroundCheckPos;
    public Vector3 groundCheckSize = Vector2.one;
    public LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        playerInputActions = new InputSystem_Actions();
    }
    private void OnEnable()
    {
        playerInputActions.Player.Jump.started += Jump;
        move = playerInputActions.Player.Move;
        playerInputActions.Enable();
    }
    private void OnDisable()
    {
        playerInputActions.Player.Jump.started -= Jump;
        playerInputActions.Disable();
    }
    private void FixedUpdate()
    {
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(cam) * movementSpeed;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(cam) * movementSpeed;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        CheckAnimation();
        forceDirection = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera cam)
    {
        Vector3 forward = cam.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera cam)
    {
        Vector3 right = cam.transform.right;
        right.y = 0;
        return right.normalized;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded() == true)
        {
            if (context.performed)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpPower, rb.linearVelocity.z);
            }
            else if (context.canceled)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f, rb.linearVelocity.z);
            }
        }   
    }
    private bool isGrounded()
    {
        if (Physics.CheckBox(GroundCheckPos.position, groundCheckSize / 2, Quaternion.identity, groundLayer))
        {
            return true;
        }
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(GroundCheckPos.position, groundCheckSize);
    }
    public void ChangeAnimation(string animation, float crossFade = 0.2f)
    {
        if (currentAnimation != animation)
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossFade);
        }
    }
    public void CheckAnimation()
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
