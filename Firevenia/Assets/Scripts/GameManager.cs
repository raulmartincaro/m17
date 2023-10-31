using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    EstadisticsInfo playerLife;
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
    private void Update()
    {
        if (playerLife.valorActual < 0)
        {
            playerLife.valorActual = 100;
            SceneManager.LoadScene("GameOver");
        }
        
    }

   

    public void Restart()
    {
        SceneManager.LoadScene("GameEscene");

    }



    
    

}
