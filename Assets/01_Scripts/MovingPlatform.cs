using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 1f; // Distancia máxima de movimiento
    public float moveSpeed = 2f; // Velocidad de movimiento
    public bool moveUp = true; // Direccion de movimiento
    private Vector3 startPosition; // Posición inicial

    void Start()
    {
        startPosition = transform.position; // Guarda la posición inicial
    }

    void Update()
    {
        // Calcula la nueva posición
        float newY = startPosition.y + (moveUp ? moveDistance : -moveDistance) * Mathf.PingPong(Time.time * moveSpeed, 1);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    // Cambiar la dirección de movimiento
    public void SwitchDirection()
    {
        moveUp = !moveUp;
    }
}
