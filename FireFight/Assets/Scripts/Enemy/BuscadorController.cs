using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuscadorController : MonoBehaviour
{
    bool m_encontrado;
    [SerializeField]
    public GameObject m_objetivo;
    public CircleCollider2D m_circle;


    public bool Encontrado => m_encontrado;
    public bool AlternativaEncontrado
    {
        get { return m_encontrado; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            m_objetivo = collision.gameObject;
            m_encontrado =true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            m_encontrado = false;
            
        }
    }

    public void cambiarRadio(float f)
    {
        m_circle.radius = f;
    }



}
