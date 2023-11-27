using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuscadorController : MonoBehaviour
{

    [SerializeField]
    GameEventInteger m_cosasAlrededor;
    private int m_cosa;

   public void comprobarAlrededor()
    {
        m_cosasAlrededor.Raise(m_cosa);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Far")
        {
            m_cosa = 1;
        }

        if (collision.gameObject.tag == "Peix")
        {
            m_cosa = 2;
        }
    }
  

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_cosa = 0;
    }

}
