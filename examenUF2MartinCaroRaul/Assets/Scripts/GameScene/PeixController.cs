using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeixController : MonoBehaviour
{
    [SerializeField]
    string m_nom; 
    [SerializeField]
    public int m_valor;
    [SerializeField]
    public int m_quantitat;
   public void loadInfo(peixosInfo p,int n)
   {
        m_nom = p.name;
        m_valor = p.preu;
        m_quantitat = n;

   }
}
