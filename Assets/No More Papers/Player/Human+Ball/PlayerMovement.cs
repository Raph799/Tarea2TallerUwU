using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isJumping = false;
    private bool isFacingRight = true;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Movimiento horizontal
        float moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // Cambiar la direcci�n del jugador
        if (moveDirection > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            Flip();
        }

        // Actualizar el par�metro "Move" en el Animator
        animator.SetFloat("Move", Mathf.Abs(moveDirection));

        // Salto
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name, collision.transform);
        // Restablecer el estado de salto cuando el jugador toca el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (collision.transform.childCount > 0 && collision.transform.GetChild(0).CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}

