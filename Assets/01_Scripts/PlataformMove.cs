using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMove : MonoBehaviour
{

    public Transform puntoA;  // El punto inicial al que se mueve el trap
    public Transform puntoB;  // El punto final de la barra
    public float velocidad = 2f;  // Velocidad de movimiento
    private bool activado = false;  // Para saber si se ha activado el movimiento
    private Vector3 posicionInicial;  // Posición inicial del trap antes de activarse
    private bool moviendoHaciaA = true;  // Estado de si el trap se mueve primero hacia puntoA

    void Start()
    {
        // Guardamos la posición inicial del trap
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (activado)
        {
            Debug.Log("Posición actual de la plataforma: " + transform.position);
            Debug.Log("Punto A: " + puntoA.position + " - Punto B: " + puntoB.position);

            if (moviendoHaciaA)
            {
                transform.position = Vector3.MoveTowards(transform.position, puntoA.position, velocidad * Time.deltaTime);
                if (Vector3.Distance(transform.position, puntoA.position) < 0.01f)
                {
                    moviendoHaciaA = false;
                }
            }
            else
            {
                float pingPong = Mathf.PingPong(Time.time * velocidad, 1);
                transform.position = Vector3.Lerp(puntoA.position, puntoB.position, pingPong);
            }
        }
    }

    public void ActivarMovimiento()
    {
        activado = true;  // Activamos el movimiento
    }
}
