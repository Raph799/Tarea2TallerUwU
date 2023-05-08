using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float glideSpeed = 2f; // Velocidad de planeo hacia abajo

    private bool isGliding = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Detectar la entrada del jugador para planear
        if (Input.GetKey(KeyCode.Space))
        {
            isGliding = true;
            rb.gravityScale = 0f; // Desactivar la gravedad mientras se planea
        }
        else
        {
            isGliding = false;
            rb.gravityScale = 1f; // Restaurar la gravedad normal cuando no se planea
        }
    }

    private void FixedUpdate()
    {
        // Aplicar velocidad de planeo hacia abajo si el jugador está planeando
        if (isGliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, -glideSpeed);
        }
    }
}
