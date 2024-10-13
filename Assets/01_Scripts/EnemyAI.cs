
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                // Llama a la función de muerte del jugador
                collision.GetComponent<PlayerHealth>().Die(); // Asegúrate de que tengas un script PlayerHealth
            }
        }
    
}
