using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaController : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;

    // Start is called before the first frame update
    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();

    }
    void Start()
    {

        m_rigidbody.velocity = new Vector3(3*(Random.Range(-1,2)),3,0);
    }

  
}
