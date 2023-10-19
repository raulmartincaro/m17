using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    GameObject m_Enemy;
    private int m_spawnNumber;

    void Start()
    {
        m_spawnNumber = 5;
        StartCoroutine("SpawnEnemies");
    }



    void Update()
    {
        
    }


    IEnumerator SpawnEnemies()
    {
        for(int x=0; x<m_spawnNumber; x++)
        {
            int orientacion=Random.Range(0, 2);

            if (orientacion == 1)
            {
                GameObject enemy = Instantiate(m_Enemy, new Vector2(-4, Random.RandomRange(-2.8f, 3f)), Quaternion.identity);
            }
            else
            {
                GameObject enemy = Instantiate(m_Enemy, new Vector2(4, Random.RandomRange(-2.8f, 3f)), Quaternion.identity);

            }


            yield return new WaitForSeconds(5);
        }
    }
}
