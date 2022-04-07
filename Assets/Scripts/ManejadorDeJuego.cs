using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManejadorDeJuego : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoEstado;

    private int puntos = 0;
    private Casilla seleccionada;

    public void Jugar(Casilla otra)
    {
        if(seleccionada == null)
        {
            seleccionada = otra;
            Debug.Log("Seleccionaron un objeto con llave:" + seleccionada.llave);
            seleccionada.ActualizarTexto(seleccionada.llave.ToString());
        }else
        {
            if(seleccionada.EsIgual(otra))
            {
                Debug.Log("Son Iguales!");
                otra.ActualizarTexto(otra.llave.ToString());
                puntos++;
            }else
            {
                Debug.Log("No Son Iguales!");
                seleccionada.ActualizarTexto("?");
                otra.ActualizarTexto("?");
                puntos--;
            }
            textoEstado.SetText("Puntos: " + puntos);
            seleccionada = null;
        }
    }

}
