using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // El objetivo que la cámara seguirá (Ecko o Nova)
    public float smoothSpeed = 0.125f; // Velocidad de la transición suave de la cámara
    public Vector3 offset; // Distancia entre la cámara y el personaje

    private void LateUpdate()
    {
        if (target != null)
        {
            // La posición deseada de la cámara basada en el personaje activo y el offset
            Vector3 desiredPosition = target.position + offset;

            // Mover la cámara de forma suave usando interpolación lineal
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Asignar la posición suavizada a la cámara
            transform.position = smoothedPosition;
        }
    }

    // Método para actualizar el objetivo de la cámara
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
