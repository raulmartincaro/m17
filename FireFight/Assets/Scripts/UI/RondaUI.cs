using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RondaUI : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI m_rondaText;
    [SerializeField]
    TextMeshProUGUI m_rondaVida;


    public void ActualizarRonda(int n)
    {
        m_rondaText.text = "Ronda: " + n;
    }

    public void ActualizarVida(int n)
    {
        m_rondaVida.text = "Vida: " + n;
    }
}
