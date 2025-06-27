using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float actionCooldown = 1f;

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;
    public KeyCode dropKey = KeyCode.S;

    public Sprite facingRightSprite;
    public Sprite facingLeftSprite;

    private Rigidbody2D rb;
    public SpriteRenderer sr;
    private bool isGrounded;
    private float lastJumpTime = -999f;

    [HideInInspector]
    public Vector2 facingDirection = Vector2.right;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private bool isJumpingOrDropping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float moveX = 0f;
        if (Input.GetKey(leftKey)) moveX = -1f;
        if (Input.GetKey(rightKey)) moveX = 1f;

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKey(leftKey))
        {
            facingDirection = Vector2.left;
            if (facingLeftSprite != null)
                sr.sprite = facingLeftSprite;
        }
        else if (Input.GetKey(rightKey))
        {
            facingDirection = Vector2.right;
            if (facingRightSprite != null)
                sr.sprite = facingRightSprite;
        }

        // Jump
        if (Input.GetKeyDown(jumpKey) && isGrounded && Time.time - lastJumpTime >= actionCooldown)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            lastJumpTime = Time.time;
            isJumpingOrDropping = true;
        }

        if (isGrounded)
        {
            isJumpingOrDropping = false;
        }
    }

    System.Collections.IEnumerator DropThrough()
    {
        PlatformEffector2D effector = GetComponent<PlatformEffector2D>();
        if (effector != null)
        {
            Collider2D col = GetComponent<Collider2D>();
            col.enabled = false;
            yield return new WaitForSeconds(0.2f);
            col.enabled = true;
        }
    }

    public bool IsJumpingOrDropping()
    {
        return isJumpingOrDropping;
    }
}
