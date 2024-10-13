
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                // Llama a la funci�n de muerte del jugador
                collision.GetComponent<PlayerHealth>().Die(); // Aseg�rate de que tengas un script PlayerHealth
            }
        }
    
}
