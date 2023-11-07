using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI m_rondaUI;

    GameManager m_gameManager;

    private void Start()
    {
        m_gameManager = GameManager.Instance;
        m_rondaUI.text = "Game Over." + "Has arribat a la ronda: " + m_gameManager.m_rondaActual;
    }

}
