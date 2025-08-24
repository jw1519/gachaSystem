using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour, IJump
{
    InputSystem_Actions playerInputActions;
    InputAction move;
    CharacterAnimationContoller animationController;

    [Header("movement")]
    public Rigidbody rb;
    public int movementSpeed;
    public int jumpPower;
    Vector3 forceDirection = Vector3.zero;
    [SerializeField] Camera cam;

    [Header("GroundCheck")]
    public Transform GroundCheckPos;
    public Vector3 groundCheckSize = Vector2.one;
    public LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //Cursor.lockState = CursorLockMode.Locked;
        playerInputActions = new InputSystem_Actions();
        animationController = GetComponent<CharacterAnimationContoller>();
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
        animationController.CheckAnimation(forceDirection, movementSpeed);
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

}
