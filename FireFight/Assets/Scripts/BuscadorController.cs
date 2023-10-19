using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuscadorController : MonoBehaviour
{


    public Action<bool> Onencontrado;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="player" ) 
        {

        }
    }
}
