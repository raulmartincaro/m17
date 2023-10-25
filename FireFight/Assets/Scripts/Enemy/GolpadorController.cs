using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpadorController : MonoBehaviour
{
    [SerializeField]
    bool m_golpeable;
    public bool Golpeable => m_golpeable;
    public bool AlternativaEncontrado
    {
        get { return m_golpeable; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            m_golpeable = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            m_golpeable = false;
        }
    }
}
