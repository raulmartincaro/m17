using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager m_Instance;
    public static GameManager Instance
    {
        get { return m_Instance; }
    }
    
    [SerializeField]
    GameEventInteger m_ConseguirPuntos;
    public int punts;
    [SerializeField]
    GameEventInteger m_PerderVidas;
    public int vides;
    [SerializeField]
    GameEventInteger m_SubirNiveles;
    public int level;

    public string m_GameOverText;

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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void Start()
    {
        InitValues();
    }

    public void recibirRecompensa(int n)
    {
        punts += n;
        m_ConseguirPuntos.Raise(punts);
    }

    public void recibirMuerte(int n)
    {
        vides -= n ;
        m_PerderVidas.Raise(vides);


        if (vides == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void recibirLevelUp(int n)
    {
        level = n;
        m_SubirNiveles.Raise(level);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            InitValues();
        }

        if (scene.name == "GameOver")
        {
            m_GameOverText = "Nivell: \n"+ level+"\n Puntució: \n"+punts;
        }        
    }
    private void InitValues()
    {
        punts = 0;
        recibirRecompensa(0);
        vides = 5;
        recibirMuerte(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");

    }

}
