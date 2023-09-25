using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI m_puntuació;
    public int punts;

    [SerializeField]
    TMPro.TextMeshProUGUI m_vides;
    public int vides;
   

    // Start is called before the first frame update
    void Start()
    {
        
        punts = 0;
        m_puntuació.text = "Puntuació: " + punts;

        vides = 5;
        m_vides.text = "Vides: " + vides;
    }

    public void recibirRecompensa(int n)
    {
        punts += n;
        m_puntuació.text = "Puntuació: " + punts;

    }

    public void recibirMuerte(int n)
    {
        vides += n;
        m_vides.text = "Vides: " + vides;


    }

}
