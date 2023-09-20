using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI m_puntuaci�;
    public int punts;

    // Start is called before the first frame update
    void Start()
    {
        
        punts = 0;
        m_puntuaci�.text = "Puntuaci�: " + punts;
    }

    public void recibirRecompensa(int n)
    {
        punts += n;
        m_puntuaci�.text = "Puntuaci�: " + punts;

    }
}
