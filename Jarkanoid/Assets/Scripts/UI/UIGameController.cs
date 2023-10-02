using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameController : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI m_puntuació;
    public int punts;

    [SerializeField]
    TMPro.TextMeshProUGUI m_vides;
    public int vides;

    [SerializeField]
    TMPro.TextMeshProUGUI m_level;
    public int level;

    private void Awake()
    {
        GameManager.ConseguirPuntos() += cambiaPuntos;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiaPuntos(int n)
    {

    }
}
