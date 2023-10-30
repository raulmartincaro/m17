using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{

    [SerializeField]
    public Vector3 m_dir;
    int velocity=5;
    Rigidbody2D m_rigibody;
    public int damage;

    private void Start()
    {
        m_rigibody = GetComponent<Rigidbody2D>();
        m_rigibody.velocity = (m_dir -this.transform.position).normalized * velocity;

    }

    private void Update()
    {
        m_rigibody.velocity = m_dir.normalized * velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "pared")
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
            Destroy(this.gameObject);
    }
}
