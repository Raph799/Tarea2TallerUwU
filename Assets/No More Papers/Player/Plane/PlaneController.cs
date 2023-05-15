using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float gravity = 2f; // Gravedad aplicada al jugador
    public float maxFallSpeed = 5f; // Velocidad constante de caída

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Desactivamos la gravedad al inicio
    }

    private void Update()
    {
        // Activamos la gravedad si la velocidad vertical del jugador es menor o igual a 0

        if (rb.velocity.y <= 0f)
        {
            rb.gravityScale = gravity;
        }
    }

    private void FixedUpdate()
    {
        // Aplicamos una velocidad de caída constante

        if (rb.gravityScale != 0f)
        {
            float newSpeedY = rb.velocity.y;
            if (newSpeedY > maxFallSpeed)
            {
                newSpeedY = maxFallSpeed;
            }

            if(newSpeedY < maxFallSpeed * -1)
            {
                newSpeedY = -maxFallSpeed;
            }
            

            rb.velocity = new Vector2(rb.velocity.x, newSpeedY);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Viento"))
        {
            rb.AddForce(Vector2.up * collision.GetComponent<Viento>().airForce, ForceMode2D.Impulse);
        }
    }
}
