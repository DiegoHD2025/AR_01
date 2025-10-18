using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.gameEnded) return;

        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectGift();

            // Opcional: mueve el regalo a una nueva posición
            // transform.position = GetRandomPosition(); 
        }
    }

    // Si quieres reubicar el regalo después de ser recogido:
    // Vector3 GetRandomPosition() { ... }
}
