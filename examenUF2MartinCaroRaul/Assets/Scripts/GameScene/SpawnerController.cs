using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    [SerializeField]
    GameObject m_tocho;
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-2.8f, 3f);
        float y = Random.Range(0f, 5f);
        Vector3 pos = new Vector3(x, y, 0);
        GameObject tochin = Instantiate(m_tocho, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
