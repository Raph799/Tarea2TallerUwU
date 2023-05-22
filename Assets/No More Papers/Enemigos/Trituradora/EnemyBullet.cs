using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Human") || other.CompareTag("Ship") || other.CompareTag("Plane") || other.CompareTag("Ball"))
        {
            Destroy(other.gameObject); // Destruye el objeto colisionado
            Destroy(gameObject); // Destruye la bala
        }
    }
}
