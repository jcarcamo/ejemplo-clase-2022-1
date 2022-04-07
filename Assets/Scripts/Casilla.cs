using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Casilla : MonoBehaviour
{
    public TMP_Text textoDelBoton;

    public int llave;

    public bool EsIgual(Casilla otraCasilla)
    {
        return llave == otraCasilla.llave;
    }

    public void ActualizarTexto(string text)
    {
        textoDelBoton.SetText(text);
    }

}
