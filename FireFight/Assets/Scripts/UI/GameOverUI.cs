using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI m_rondaUI;
    [SerializeField]
    EstadisticsInfo m_stadisticsRonda;

    private void Start()
    {
        m_rondaUI.text = "Game Over." + "Has arribat a la ronda: " + m_stadisticsRonda.valorActual;
    }

}
