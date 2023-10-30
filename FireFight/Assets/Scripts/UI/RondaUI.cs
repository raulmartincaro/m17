using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RondaUI : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI m_rondaText;
    [SerializeField]
    TextMeshProUGUI m_rondaVida;
    [SerializeField]
    EstadisticsInfo m_stadisticsRonda;
    [SerializeField]
    EstadisticsInfo m_stadisticsVida;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        m_rondaText.text= "Ronda: " +  m_stadisticsRonda.valorActual;
        m_rondaVida.text = "Vida: " + m_stadisticsVida.valorActual;
    }
}
