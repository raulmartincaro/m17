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
        m_rigidbody.velocity = new Vector3(3 * (Random.Range(-1f, 2f)), 3, 0);
    }



    private void OnDestroy()
    {
        laMoricion.Raise(1);
        StopAllCoroutines();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 f=new Vector2(0,0);
        if (this.m_rigidbody.velocity.x == 0)
        {
            if (this.m_rigidbody.position.x >= 0)
                f = new Vector2(-8, 0);
            else
                f = new Vector2(8, 0);

        }
        if (this.m_rigidbody.velocity.y == 0)
        {
            if (this.m_rigidbody.position.y >= 0)
                f = new Vector2(0, -8);
            else
                f = new Vector2(0, 8);

        }
        this.m_rigidbody.AddForce(f);
    }
}
