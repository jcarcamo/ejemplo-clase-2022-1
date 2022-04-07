using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadorEnemigo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Jugador")
        {
            Debug.Log("Choque con el jugador");
            ControladorBloby b = collision.gameObject.GetComponent<ControladorBloby>();
            b.ReducirVida();
        }
    }
}
