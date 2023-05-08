using UnityEngine;

public class DetenerMovimientoGround : MonoBehaviour
{
    private bool jugadorEncima; // Indica si el jugador está sobre el objeto

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto que colisionó es el jugador
        if (collision.collider.CompareTag("Player"))
        {
            jugadorEncima = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Verificar si el objeto que dejó de colisionar es el jugador
        if (collision.collider.CompareTag("Player"))
        {
            jugadorEncima = false;
        }
    }

    private void FixedUpdate()
    {
        // Detener el movimiento del componente solo si el jugador está encima
        if (jugadorEncima)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
