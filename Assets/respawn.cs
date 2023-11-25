using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 posicionReinicio = new Vector3(0f, 0f, -489f);

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisionó tiene el tag "Player".
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered respawn zone.");

            // Obtén el componente Rigidbody del jugador para manejar la rotación.
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            // Verifica si el objeto tiene un Rigidbody.
            if (playerRigidbody != null)
            {
                Debug.Log("Player has Rigidbody.");

                // Detén la velocidad del jugador.
                playerRigidbody.velocity = Vector3.zero;
                playerRigidbody.angularVelocity = Vector3.zero;

                // Rotación inicial (ajústalo según tus necesidades).
                Quaternion rotacionInicial = Quaternion.identity;
                playerRigidbody.MoveRotation(rotacionInicial);

                Debug.Log("Player's velocity and rotation reset.");
            }

            // Devuelve al personaje a la posición de reinicio.
            other.transform.position = posicionReinicio;

            Debug.Log("Player respawned at: " + posicionReinicio);
        }
    }
}
