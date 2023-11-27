using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI m_puntuació;
    public int punts;

    public void cambiaPuntos(int n)
    {
        m_puntuació.text = ""+ n;
    }
}
