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
    TMPro.TextMeshProUGUI m_puntuació;
    public int punts;

    [SerializeField]
    TMPro.TextMeshProUGUI m_vides;
    public int vides;

    [SerializeField]
    TMPro.TextMeshProUGUI m_level;
    public int level;

    public delegate void ConseguirPuntos(int p);
    public event ConseguirPuntos OnConseguirPuntos;
    public delegate void PerderVidas(int v);
    public event PerderVidas OnPerderVidas;
    public delegate void SubirNiveles(int n);
    public event SubirNiveles OnSubirNiveles;

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
        InitValues();


    }


    public void recibirRecompensa(int n)
    {
        punts += n;
        OnConseguirPuntos.Invoke(punts);
        m_puntuació.text = "Puntuació: " + punts;
    }

    public void recibirMuerte(int n)
    {
        vides -= n ;
        OnPerderVidas.Invoke(vides);
        m_vides.text = "Vides: " + vides;
        if(vides == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void recibirLevelUp(int n)
    {
        level = n;
        OnSubirNiveles.Invoke(level);
        m_level.text = "Nivell: " + level;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
            InitValues();

        if (scene.name == "GameOver")
        {
            m_GameOverText = "Nivell: \n"+ level+"\n Puntució: \n"+punts;

        }
            
    }
    private void InitValues()
    {
        punts = 0;
        vides = 5;
        level = 1;
        m_puntuació.text = "Puntuació: " + punts;
        m_vides.text = "Vides: " + vides;
        m_level.text = "Nivell: " + level;
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");

    }

}
