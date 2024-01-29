using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D playerRb;

    private float jumpVelocity = 10f;

    private float movementVelocity = 5f;

    private float axisX;

    private BoxCollider2D groundCollider;

    [SerializeField]
    private LayerMask ground;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
        groundCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        axisX = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector2(axisX * movementVelocity, playerRb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpVelocity);
        }

        Run();
        Flip();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(groundCollider.bounds.center, groundCollider.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }

    private void Flip()
    {
        if(axisX < 0f)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void Run()
    {
        if (axisX > 0f || axisX < 0f)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }
}
