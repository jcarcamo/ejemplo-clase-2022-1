using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControladorBloby : MonoBehaviour
{
    [SerializeField]
    private float velocidad = 4f;
    [SerializeField]
    private float fuerzaSalto = 1f;

    [SerializeField]
    private int vidas = 3;
    [SerializeField]
    private int puntos;

    private float direccion;
    private bool miraIzquierda = false;

    [SerializeField]
    private TMP_Text txtVidas;

    [SerializeField]
    private TMP_Text txtPuntos;

    private Rigidbody2D rigidbody2D;


    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        txtVidas.SetText(vidas.ToString());
        txtPuntos.SetText(puntos.ToString());
    }

    public void ReducirVida()
    {
        vidas--;
        txtVidas.SetText(vidas.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        direccion = Input.GetAxisRaw("Horizontal");
        if(direccion < 0 && !miraIzquierda)
        {
            miraIzquierda = true;
            Flip();

        }else if(direccion > 0 && miraIzquierda)
        {
            miraIzquierda = false;
            Flip();
        }
        if(Input.GetButtonDown ("Jump"))
        {
            rigidbody2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse); ;
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        
        if(collider.gameObject.tag == "Coleccionable")
        {
            Coleccionable c = collider.gameObject.GetComponent<Coleccionable>();
            puntos += c.GetPuntos();
            txtPuntos.SetText(puntos.ToString());
            Destroy(collider.gameObject);
        }
        if(vidas <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(direccion * velocidad, rigidbody2D.velocity.y);
    }

    private void Flip()
    {
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
