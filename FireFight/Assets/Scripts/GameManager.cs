using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    EstadisticsInfo m_vida;
    [SerializeField]
    EstadisticsInfo m_ronda;

    [SerializeField]
    GameEventInteger m_rondaFinal;

    public int m_rondaActual;
   
    private static GameManager m_Instance;
    public static GameManager Instance
    {
        get { return m_Instance; }
    }

    private void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }


    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Restart()
    {
        m_vida.valorActual = 100;
        SceneManager.LoadScene("GameEscene");
       
    }

}
