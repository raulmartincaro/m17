using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    GameObject m_tocho;
    


    int spawnNumb;
   
    void Start()
    {

        spawnNumb = 12;
        for(int q = 0; q < spawnNumb; q++)
        {
            float x = Random.Range(-2.8f, 3f);
            float y = Random.Range(0f, 5f);
            Vector3 pos = new Vector3(x, y, 0);
            Instantiate(m_tocho, pos, Quaternion.identity);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
