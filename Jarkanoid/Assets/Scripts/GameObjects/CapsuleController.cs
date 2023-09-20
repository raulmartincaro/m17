using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    int recompensa;
    public void LoadInfo(CapsuleInfo capsuleInfo)
    {
       
        GetComponent<SpriteRenderer>().color = capsuleInfo.color;
        recompensa = capsuleInfo.valor;
    }
    
}
