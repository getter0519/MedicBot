using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
  

    public int timer = 1;

    public int damage = 20;

    public float tiempoDeVida = 3.0f; // Tiempo en segundos antes de destruir la bala
    private void Start()
    {
        // Comenzar una corutina que destruir� la bala despu�s de un tiempo especificado
        StartCoroutine(DestruirDespuesDeTiempo());
        Destroy(gameObject, timer);
    }

    private IEnumerator DestruirDespuesDeTiempo()
    {
        // Esperar el tiempo especificado antes de destruir la bala
        yield return new WaitForSeconds(tiempoDeVida);

        // Destruir la bala
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Destroy(gameObject);
        }
        // Verificar si la colisi�n es con un enemigo
        if (collision.CompareTag("Enemigo"))
        {
            EnemigoVida enemyHealth = collision.GetComponent<EnemigoVida>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage); // Aplicar da�o al enemigo
            }
            // Destruir la bala despu�s de la colisi�n
            Destroy(gameObject);
        }
        if (collision.CompareTag("Piso"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Infeccion"))
        {
            Destroy(gameObject);
        }
        // Verificar si la colisi?n es con un enemigo
        if (collision.CompareTag("Infeccion"))
        {
            InfeccionMatar enemyHealth = collision.GetComponent<InfeccionMatar>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage); // Aplicar da?o al enemigo
            }

            // Destruir la bala despu?s de la colisi?n
            Destroy(gameObject);
        }
    }
}
