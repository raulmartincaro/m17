using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Rendering;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    GameObject m_tocho;
    [SerializeField]
    List<GameObject> m_MyTochos;
    [SerializeField]
    GameEventInteger m_LevelUp;
   
    


    int spawnNumb;
   
    void Start()
    {
        Assert.IsNotNull(m_tocho.GetComponent<BloqueController>());

        spawnNumb = 12;
        for(int q = 0; q < spawnNumb; q++)
        {
            float x = Random.Range(-2.8f, 3f);
            float y = Random.Range(0f, 5f);
            Vector3 pos = new Vector3(x, y, 0);
            GameObject tochin = Instantiate(m_tocho, pos, Quaternion.identity);
            m_MyTochos.Add(tochin);
            tochin.GetComponent<BloqueController>().OnBloqueDestroyed += OnBloqueDestroyed;
        }
    }

    private void OnBloqueDestroyed(GameObject go)
    {
        go.GetComponent<BloqueController>().OnBloqueDestroyed -= OnBloqueDestroyed;
        m_MyTochos.Remove(go);
        if (m_MyTochos.Count == 0)
        {

        }
    }
}
