using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaController : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;

    [SerializeField]
    GameEventInteger laMoricion;
    Vector2 m_position;

    // Start is called before the first frame update
    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(comprobacionEncallado());

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

    IEnumerator comprobacionEncallado()
    {
        while (true)
        {
            m_position = this.transform.position;
            yield return new WaitForSeconds(5f);
            if (m_position.x == this.transform.position.x)
            {
                Debug.Log("empujo en x");
                Vector2 f = new Vector2(4, 0);
                this.m_rigidbody.AddForce(f);
            }
            if (m_position.y == this.transform.position.y)
            {
                Debug.Log("empujo en y");
                Vector2 f = new Vector2(0, -4);
                this.m_rigidbody.AddForce(f);
            }
        }
    }
}
