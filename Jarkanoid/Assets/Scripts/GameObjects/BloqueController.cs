using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BloqueController : MonoBehaviour
{
    [SerializeField]
    GameEventInteger m_DarRecompensa;

    [SerializeField]
    private GameObject m_capsule;

    [SerializeField]
    private CapsuleInfo[] m_capsuleInfos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pelota")
        {
            int rng = Random.Range(1, 101);
            
            switch (rng)
            {
                case < 90:
                    m_capsule.GetComponent<CapsuleController>().LoadInfo(m_capsuleInfos[2]);
                break;
                case > 90:
                    m_capsule.GetComponent<CapsuleController>().LoadInfo(m_capsuleInfos[1]);
                    break;
                case > 11:
                    m_capsule.GetComponent<CapsuleController>().LoadInfo(m_capsuleInfos[0]);
                break;
            }
            Instantiate(m_capsule, this.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
            m_DarRecompensa.Raise(100);



            


        }
    }
}
