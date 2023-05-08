using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float groundSpeed = 5f;    // Velocidad en tierra
    public float waterSpeed = 10f;    // Velocidad en agua

    private bool isGrounded = false;  // Variable para comprobar si el jugador está en tierra
    private bool isWater = false;     // Variable para comprobar si el jugador está en agua

    private Rigidbody2D rb;
    private int groundColliders = 0;  // Contador de colliders de tierra
    private int waterColliders = 0;   // Contador de colliders de agua

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        // Comprobar si el jugador está en tierra o en agua
        if (isGrounded)
        {
            rb.velocity = new Vector2(horizontalMovement * groundSpeed, rb.velocity.y);
        }
        else if (isWater)
        {
            rb.velocity = new Vector2(horizontalMovement * waterSpeed, rb.velocity.y);
        }

        // Cambiar la dirección de la imagen del personaje según el sentido del movimiento
        if (horizontalMovement < 0)
        {
            spriteRenderer.flipX = true; // Voltear horizontalmente
        }
        else if (horizontalMovement > 0)
        {
            spriteRenderer.flipX = false; // No voltear horizontalmente
        }

        // Saltar (añade tu propia lógica de salto aquí)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Añade aquí el código para el salto
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundColliders++;
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Water"))
        {
            waterColliders++;
            isWater = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundColliders--;
            if (groundColliders <= 0)
            {
                isGrounded = false;
            }
        }
        else if (collision.gameObject.CompareTag("Water"))
        {
            waterColliders--;
            if (waterColliders <= 0)
            {
                isWater = false;
            }
        }
    }
}
