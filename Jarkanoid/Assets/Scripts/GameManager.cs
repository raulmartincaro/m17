using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI m_puntuació;
    public int punts;

    // Start is called before the first frame update
    void Start()
    {
        
        punts = 0;
        m_puntuació.text = "Puntuació: " + punts;
    }

    public void recibirRecompensa(int n)
    {
        punts += n;
        m_puntuació.text = "Puntuació: " + punts;

    }
}
