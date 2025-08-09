using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour, IJump
{
    public Rigidbody rb;
    public int movementSpeed;
    public int jumpPower;

    [Header("GroundCheck")]
    public Transform GroundCheckPos;
    public Vector3 groundCheckSize = Vector2.one;
    public LayerMask groundLayer;

    float horizontalMovement;
    float verticalMovement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        Vector3 move = new Vector3(horizontalMovement, 0, verticalMovement) * movementSpeed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        horizontalMovement = input.x;
        verticalMovement = input.y;
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
