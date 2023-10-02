using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonRestartController : MonoBehaviour
{

    
    GameManager manager;

    void Awake()
    {
        manager = GameManager.Instance;

    }
    public void volverJugar()
    {

        manager.GetComponent<GameManager>().Restart();
    }

}
