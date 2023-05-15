using UnityEngine;
using System.Collections.Generic;


public class FlameMovement : MonoBehaviour
{
    public float speed = 5f;         // Velocidad de movimiento del enemigo
    public float detectionRadius = 5f;   // Radio de detecci�n para seguir al jugador
    public float floatAmplitude = 1f;    // Amplitud del movimiento de flotaci�n
    public float floatFrequency = 1f;    // Frecuencia del movimiento de flotaci�n

    private Transform player;           // Referencia al transform del jugador
    private bool isFollowing = false;    // Indicador de si el enemigo est� siguiendo al jugador
    private float floatTimer = 0f;       // Temporizador para el movimiento de flotaci�n
    private Vector3 startingPosition;    // Posici�n inicial del enemigo
    private float randomOffset;          // Desplazamiento aleatorio de izquierda a derecha

    void Start()
    {
        startingPosition = transform.position;
        randomOffset = Random.Range(-1f, 1f);
    }

    void Update()
    {
        if (player == null)
        {
            FindPlayer();
            return;
        }

        // Calcula la distancia entre el enemigo y el jugador
        float distance = Vector3.Distance(transform.position, player.position);

        // Si el jugador est� dentro del radio de detecci�n y est� activo, comienza a seguirlo
        if (distance <= detectionRadius)
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }

        // Si est� siguiendo al jugador, mueve el enemigo en direcci�n al jugador
        if (isFollowing)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            // Movimiento de flotaci�n cuando no sigue al jugador
            floatTimer += Time.deltaTime;
            float yOffset = Mathf.Sin(floatTimer * floatFrequency) * floatAmplitude;
            float xOffset = Mathf.Sin(floatTimer * floatFrequency * 0.5f + randomOffset) * floatAmplitude;
            transform.position = startingPosition + new Vector3(xOffset, yOffset, 0f);
        }
    }

    private void FindPlayer()
    {
        List<GameObject> players = new List<GameObject>();

        players.AddRange(GameObject.FindGameObjectsWithTag("Human"));
        players.AddRange(GameObject.FindGameObjectsWithTag("Ship"));
        players.AddRange(GameObject.FindGameObjectsWithTag("Ball"));
        players.AddRange(GameObject.FindGameObjectsWithTag("Plane"));

        foreach (GameObject p in players)
        {
            if (p.activeSelf)
            {
                player = p.transform;
                break;
            }
        }
    }
}

