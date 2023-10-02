using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI m_texto;

    GameManager manager;

    void Awake()
    {
        manager = GameManager.Instance;
       
    }

    private void Start()
    {
        m_texto.text = manager.GetComponent<GameManager>().m_GameOverText;
    }


}
