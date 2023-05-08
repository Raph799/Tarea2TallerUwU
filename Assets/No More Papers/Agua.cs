using UnityEngine;
using TMPro;

public class Agua : MonoBehaviour
{
    public TextMeshProUGUI gameOverText; // Referencia al objeto de TextMeshPro que mostrará "Game Over"

    private void Start()
    {
        gameOverText.enabled = false; // Inicialmente, desactivamos el texto de "Game Over"
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto que colisionó es el personaje
        if (other.CompareTag("Human") || other.CompareTag("Plane") || other.CompareTag("Ball"))
        {
            // Desactivar al personaje para que no pueda moverse
            other.gameObject.SetActive(false);

            // Mostrar el texto de "Game Over"
            gameOverText.enabled = true;
        }
    }
}
