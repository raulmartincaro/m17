using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI m_puntuaci�;
    public int punts;

    [SerializeField]
    TMPro.TextMeshProUGUI m_vides;
    public int vides;
   

    // Start is called before the first frame update
    void Start()
    {
        
        punts = 0;
        m_puntuaci�.text = "Puntuaci�: " + punts;

        vides = 5;
        m_vides.text = "Vides: " + vides;
    }

    public void recibirRecompensa(int n)
    {
        punts += n;
        m_puntuaci�.text = "Puntuaci�: " + punts;

    }

    public void recibirMuerte(int n)
    {
        vides += n;
        m_vides.text = "Vides: " + vides;


    }

}
