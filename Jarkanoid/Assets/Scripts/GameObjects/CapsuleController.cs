using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    [SerializeField]
    int recompensa;
    [SerializeField]
    GameEventInteger darRecompensa;
    public bool powerUp;

    public void LoadInfo(CapsuleInfo capsuleInfo)
    {
       
        GetComponent<SpriteRenderer>().color = capsuleInfo.color;
        recompensa = capsuleInfo.valor;
        powerUp = capsuleInfo.powerUp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            darRecompensa.Raise(recompensa);
            Destroy(this.gameObject);
        }
    }

}
