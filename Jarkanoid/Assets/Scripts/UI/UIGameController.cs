using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameController : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI m_puntuaci�;
    public int punts;

    [SerializeField]
    TMPro.TextMeshProUGUI m_vides;
    public int vides;

    [SerializeField]
    TMPro.TextMeshProUGUI m_level;
    public int level;


    public void cambiaPuntos(int n)
    {
        m_puntuaci�.text = "Puntuaci�: " + n;
    }
    public void pierdeVidas(int n)
    {
        m_vides.text = "Vides: " + n;
    }
    public void subirNiveles(int n)
    {
        m_level.text = "Nivell: " + n;
    }
}
