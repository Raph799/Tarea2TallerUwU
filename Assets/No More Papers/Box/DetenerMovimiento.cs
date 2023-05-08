using UnityEngine;

public class DetenerMovimiento : MonoBehaviour
{
    private Rigidbody2D rb; // Referencia al componente Rigidbody2D de la caja
    private bool jugadorTocando; // Indica si el jugador est� tocando la caja

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D de la caja
    }

    private void Update()
    {
        if (!jugadorTocando && rb.velocity != Vector2.zero)
        {
            // Detener el movimiento de la caja
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto que colision� es el jugador
        if (collision.collider.CompareTag("Human"))
        {
            jugadorTocando = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Verificar si el objeto que dej� de colisionar es el jugador
        if (collision.collider.CompareTag("Human"))
        {
            jugadorTocando = false;
        }
    }
}
