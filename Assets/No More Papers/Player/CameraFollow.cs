using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                // Transform del objetivo principal
    public Transform[] additionalTargets;   // Array de referencias a los transform de los objetivos adicionales
    public float smoothSpeed = 0.125f;      // Velocidad de suavizado de movimiento de la cámara
    public Vector3 offset;                  // Distancia inicial entre la cámara y los objetivos
    public float minX, maxX;                // Límites horizontales de la cámara
    public float minY, maxY;                // Límites verticales de la cámara

    void LateUpdate()
    {
        // Verifica si hay al menos un objetivo
        if (target == null && additionalTargets.Length == 0)
            return;

        // Calcula el promedio de las posiciones de los objetivos
        Vector3 averagePosition = GetAveragePosition();

        // Calcula la posición deseada de la cámara
        Vector3 desiredPosition = averagePosition + offset;

        // Limita la posición dentro de los límites establecidos
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);

        // Calcula la posición suavizada de la cámara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualiza la posición de la cámara
        transform.position = smoothedPosition;
    }

    Vector3 GetAveragePosition()
    {
        Vector3 averagePos = target.position;

        // Calcula el promedio de las posiciones de los objetivos adicionales
        for (int i = 0; i < additionalTargets.Length; i++)
        {
            averagePos += additionalTargets[i].position;
        }

        // Divide por el número total de objetivos para obtener el promedio
        int totalTargets = additionalTargets.Length + 1;
        averagePos /= totalTargets;

        return averagePos;
    }
}
