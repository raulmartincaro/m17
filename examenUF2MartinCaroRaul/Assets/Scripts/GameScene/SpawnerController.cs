using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    [SerializeField]
    GameObject m_peix;
    List<GameObject> m_misPeces;
    [SerializeField]
    List<peixosInfo> m_peixosInfos;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
  public void Spawn()
    {
        for(int l = 0; l < 5; l++)
        {
            float x = Random.Range(-8.5f, 8.5f);
            float y = Random.Range(-4.4f, 4.3f);
            Vector3 pos = new Vector3(x, y, 0);
            GameObject pez = Instantiate(m_peix, pos, Quaternion.identity);
            int aparicion= Random.Range(0, 101);
            int cantidad;
            int especie;

            switch (aparicion)
            {
                case >80:
                    especie = 2;
                    cantidad = Random.Range(1, 4);
                break;
                case > 50:
                    especie = 1;
                    cantidad = Random.Range(2, 8);
                break;
                default:
                    especie = 0;
                    cantidad = Random.Range(5, 21);
               break;
            }

            pez.GetComponent<PeixController>().loadInfo(m_peixosInfos[especie],cantidad);
            //m_misPeces.Add(pez);
        }
    }
       
}
