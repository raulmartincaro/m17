using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    GameObject m_Enemy;
    private int m_spawnNumber;
    private int m_ronda;
    private bool m_finSpawn;
    private List<GameObject> m_misHijos;

    void Start()
    {
        m_spawnNumber = 5;
        StartCoroutine(SpawnEnemies());
        m_ronda = 1;
        m_finSpawn = false;
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
                GameObject enemy = Instantiate(m_Enemy, new Vector2(-4, Random.Range(-2.8f, 3f)), Quaternion.identity);
                m_misHijos.Add(enemy);
            }
            else
            {
                GameObject enemy = Instantiate(m_Enemy, new Vector2(4, Random.Range(-2.8f, 3f)), Quaternion.identity);
                m_misHijos.Add(enemy);
            }
           // enemy.GetComponent<EnemyController>().OnEnemyDestroyed += enemyDie;
            

            yield return new WaitForSeconds(5);
        }
        m_finSpawn = true;
    }

   /* private void enemyDie(GameObject go)
    {
        go.GetComponent<EnemyController>().OnEnemyDestroyed -= enemyDie;
        m_misHijos.Remove(go);
        if (m_misHijos.Count == 0 && m_finSpawn==true)
        {
            m_ronda++;
            m_spawnNumber = 5 + (m_ronda * 3);
            StartCoroutine("SpawnEnemies");
        }
    }*/
}
