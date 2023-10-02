using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaController : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;

    [SerializeField]
    GameEventInteger laMoricion;

    // Start is called before the first frame update
    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        m_rigidbody.velocity = new Vector3(3*(Random.Range(-1f,2f)),3,0);
    }

    private void OnDestroy()
    {
        laMoricion.Raise(1);
    }

}
