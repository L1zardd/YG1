 using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private Animator anim;

    private int jumpCount = 0;
    public int maxJumpCount = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing from this GameObject. Please add a Rigidbody2D.");
        }
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (moveHorizontal > 0.01f)
            transform.localScale = Vector3.one;
        if (moveHorizontal < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }

        if (rb.velocity.y == 0)
        {
            jumpCount = 0;
        }

        anim.SetBool("Run",moveHorizontal != 0);
    }
}