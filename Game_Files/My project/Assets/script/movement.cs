using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody rb;
    private bool isGrounded;
    private int jumpCount = 0;
    public int maxJumpCount = 2; // Allow double jump

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(move * moveSpeed, rb.velocity.y, rb.velocity.z);

        // Jump
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumpCount))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            jumpCount++;
        }

        // Reset jump count when grounded
        if (isGrounded)
        {
            jumpCount = 0;
        }

        // Check if grounded
        isGrounded = IsGrounded();
    }

    private bool IsGrounded()
    {
        // Use a raycast to check if the player is grounded
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
