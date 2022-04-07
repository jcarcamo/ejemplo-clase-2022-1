using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    [SerializeField]
    private int puntos;

    public int GetPuntos()
    {
        return puntos;
    }
}
