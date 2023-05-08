using UnityEngine;

public class EmpujarObjeto : MonoBehaviour
{
    private Rigidbody2D rb; // Referencia al componente Rigidbody2D del personaje

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D del personaje
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto que colisionó tiene el tag "Box"
        if (collision.collider.CompareTag("Box"))
        {
            // Obtener el componente Rigidbody2D del objeto empujable
            Rigidbody2D objetoRigidbody = collision.collider.GetComponent<Rigidbody2D>();

            if (objetoRigidbody != null)
            {
                // Calcular la dirección en la que se empujará el objeto
                Vector2 direccionEmpuje = rb.velocity.normalized;

                // Aplicar una fuerza al objeto para empujarlo
                objetoRigidbody.AddForce(direccionEmpuje, ForceMode2D.Impulse);
            }
        }
    }
}
