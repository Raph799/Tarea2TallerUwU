using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject prefabMain; // Prefab del personaje humano
    public GameObject prefab1; // Prefab del personaje nave
    public GameObject prefab2; // Prefab del personaje humano
    public GameObject prefab3; // Prefab del personaje nave

    public CameraFollow cameraFollow; // Referencia al script de seguimiento de la cámara

    private GameObject currentCharacter; // Personaje actual
    private Vector3 savedPosition; // Posición guardada del personaje actual
    private int currentState = 1; // Estado actual (1: Humano, 2: Nave)

    private void Start()
    {
        // Asigna el personaje inicial
        SwitchToMain();
    }

    private void Update()
    {
        // Cambiar de estado al presionar la tecla correspondiente
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentState != 1)
        {
            SwitchToMain();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && currentState != 2)
        {
            SwitchTo1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && currentState != 3)
        {
            SwitchTo2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && currentState != 4)
        {
            SwitchTo3();
        }
    }

    public void SwitchToMain()
    {
        // Guardar la posición actual
        savedPosition = currentCharacter != null ? currentCharacter.transform.position : transform.position;

        // Destruir el personaje actual
        Destroy(currentCharacter);

        // Instanciar el personaje humano en la posición guardada
        currentCharacter = Instantiate(prefabMain, savedPosition, Quaternion.identity);

        // Actualizar el estado actual
        currentState = 1;

        // Actualizar el objetivo principal de la cámara
        cameraFollow.target = currentCharacter.transform;
    }

    public void SwitchTo1()
    {
        // Guardar la posición actual
        savedPosition = currentCharacter != null ? currentCharacter.transform.position : transform.position;

        // Destruir el personaje actual
        Destroy(currentCharacter);

        // Instanciar el personaje nave en la posición guardada
        currentCharacter = Instantiate(prefab1, savedPosition, Quaternion.identity);

        // Actualizar el estado actual
        currentState = 2;

        // Actualizar el objetivo principal de la cámara
        cameraFollow.target = currentCharacter.transform;
    }

    public void SwitchTo2()
    {
        // Guardar la posición actual
        savedPosition = currentCharacter != null ? currentCharacter.transform.position : transform.position;

        // Destruir el personaje actual
        Destroy(currentCharacter);

        // Instanciar el personaje humano en la posición guardada
        currentCharacter = Instantiate(prefab2, savedPosition, Quaternion.identity);

        // Actualizar el estado actual
        currentState = 3;

        // Actualizar el objetivo principal de la cámara
        cameraFollow.target = currentCharacter.transform;
    }

    public void SwitchTo3()
    {
        // Guardar la posición actual
        savedPosition = currentCharacter.transform.position;

        // Destruir el personaje actual
        Destroy(currentCharacter);

        // Instanciar el personaje nave en la posición guardada
        currentCharacter = Instantiate(prefab3, savedPosition, Quaternion.identity);

        // Actualizar el estado actual
        currentState = 4;

        // Actualizar el objetivo principal de la cámara
        cameraFollow.target = currentCharacter.transform;
    }
}