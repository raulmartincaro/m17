using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaController : MonoBehaviour
{
    public Rigidbody2D m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();

        m_rigidbody.velocity = new Vector3(1,1,0);
    }

    // Update is called once per frame
    void Update()
    {
       // m_rigidbody.velocity = new Vector3(1, 1, 0);

    }
}
