using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminatorController : MonoBehaviour
{
    public delegate void zemurio();
    public event zemurio onzemuriose;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Pelota")
        {
            Destroy(col.gameObject);
            onzemuriose.Invoke();
        }
        
    }
}
