using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   
    BuscadorController m_deteccion;
    GolpadorController m_deteccionGolpeacion;
  
    void Start()
    {
        m_deteccion= GetComponentInChildren<BuscadorController>();
        m_deteccionGolpeacion = GetComponentInChildren<GolpadorController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_deteccion.Encontrado)
        {
            Debug.Log("Te veoooooo!!!!!");

        }
        if(m_deteccionGolpeacion.Golpeable)
        {
            Debug.Log("Te pegoooooooo!!!!!");
        }
       
    }
}
