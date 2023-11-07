using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

public class SpawnerController : MonoBehaviour
{

    

    [SerializeField]
    List<EnemyInfo> m_infoSpawn;
    [SerializeField]
    GameObject m_EnemySpawnMelee;
    [SerializeField]
    GameObject m_EnemySpawnRanger;
    [SerializeField]
    private int m_spawnNumber;
    [SerializeField]
    private EstadisticsInfo m_ronda;
    [SerializeField]
    private bool m_finSpawn;
    [SerializeField]
    private List<GameObject> m_misHijos;

    [SerializeField]
    public GameEventInteger m_cambioRonda;



    void Start()
    {
        Assert.IsNotNull(m_EnemySpawnMelee.GetComponent<EnemyController>());
        Assert.IsNotNull(m_EnemySpawnRanger.GetComponent<EnemyControllerDisparador>());

        m_spawnNumber = 5;
        m_ronda.valorActual = 1;
        m_cambioRonda.Raise(m_ronda.valorActual);
        StartCoroutine(SpawnEnemies());
        m_finSpawn = false;
    }

   

    void Update()
    {
        
    }


    IEnumerator SpawnEnemies()
    {
        for(int x=0; x<m_spawnNumber; x++)
        {

            if (m_ronda.valorActual == 2)
            {
                GameObject enemy = Instantiate(m_EnemySpawnRanger, new Vector2(4, UnityEngine. Random.Range(-2.8f, 3f)), Quaternion.identity);
                enemy.GetComponent<EnemyControllerDisparador>().LoadInfo(m_infoSpawn[1]);
                m_misHijos.Add(enemy);
                enemy.GetComponent<EnemyControllerDisparador>().OnEnemyRangedDestroyed += enemyDie;
               
            } else { 


                int ranger = 0;
                 if (m_ronda.valorActual > 1)
                 {
               
                     ranger= UnityEngine.Random.Range(0, 2);
                 }
                int orientacion= UnityEngine.Random.Range(0, 2);
                if (orientacion == 1)
                {
                
                    GameObject enemy = Instantiate(m_EnemySpawnMelee, new Vector2(-4, UnityEngine.Random.Range(-2.8f, 3f)), Quaternion.identity);
                    enemy.GetComponent<EnemyController>().LoadInfo(m_infoSpawn[0]);
                    m_misHijos.Add(enemy);
                    enemy.GetComponent<EnemyController>().OnEnemyDestroyed += enemyDie;
                }else{
                    if (ranger == 1)
                    {
                        GameObject enemy = Instantiate(m_EnemySpawnRanger, new Vector2(4, UnityEngine.Random.Range(-2.8f, 3f)), Quaternion.identity);
                        enemy.GetComponent<EnemyControllerDisparador>().LoadInfo(m_infoSpawn[1]);
                        m_misHijos.Add(enemy);
                        enemy.GetComponent<EnemyControllerDisparador>().OnEnemyRangedDestroyed += enemyDie;
                    }else{
                        GameObject enemy = Instantiate(m_EnemySpawnMelee, new Vector2(4, UnityEngine.Random.Range(-2.8f, 3f)), Quaternion.identity);
                        enemy.GetComponent<EnemyController>().LoadInfo(m_infoSpawn[0]);
                        m_misHijos.Add(enemy);
                        enemy.GetComponent<EnemyController>().OnEnemyDestroyed += enemyDie;
                    }

               
                }

            }
            yield return new WaitForSeconds(3);

        }


        m_finSpawn = true;
    }

   private void enemyDie(GameObject go)
    {
        if (go.GetComponent<EnemyController>() is EnemyController meleeEnemy)
        {
            go.GetComponent<EnemyController>().OnEnemyDestroyed -= enemyDie;

        }
        else
        {
            go.GetComponent<EnemyControllerDisparador>().OnEnemyRangedDestroyed -= enemyDie;

        }
        m_misHijos.Remove(go);
        if (m_misHijos.Count == 0 && m_finSpawn==true)
        {
            m_ronda.valorActual++;
            m_cambioRonda.Raise(m_ronda.valorActual);
            m_spawnNumber = 5 + (m_ronda.valorActual * 3);
            StartCoroutine("SpawnEnemies");
            m_finSpawn = false;
        }
    }

    


}
