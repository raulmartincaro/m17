using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BloqueController : MonoBehaviour
{
    [SerializeField]
    GameEventInteger m_Destrucccion;
    
    [SerializeField]
    private GameObject m_capsule;

    [SerializeField]
    private CapsuleInfo[] m_capsuleInfos;

    public delegate void BloqueDestroyed(GameObject go);
    public event BloqueDestroyed OnBloqueDestroyed;

    [SerializeField]
    private AudioClip m_clip1;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Pelota")
        {
            OnBloqueDestroyed?.Invoke(gameObject);
            
            m_Destrucccion.Raise(100);
            int rng = Random.Range(1, 101);
            switch (rng)
            {
                case > 76:
                    m_capsule.GetComponent<CapsuleController>().LoadInfo(m_capsuleInfos[3]);
                break;
                case > 50:
                    m_capsule.GetComponent<CapsuleController>().LoadInfo(m_capsuleInfos[2]);
                    break;
                case > 25:
                    m_capsule.GetComponent<CapsuleController>().LoadInfo(m_capsuleInfos[1]);
                    break;
                default:
                    m_capsule.GetComponent<CapsuleController>().LoadInfo(m_capsuleInfos[0]);
                break;
            }
            Instantiate(m_capsule, this.transform.position, Quaternion.identity);
            GameManager.Instance.ReproducirSonido(m_clip1);
            Destroy(this.gameObject);
        }
    }
}
