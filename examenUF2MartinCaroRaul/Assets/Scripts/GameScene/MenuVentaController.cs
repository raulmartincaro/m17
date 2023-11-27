using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuVentaController : MonoBehaviour
{
    public void activarse(bool t)
    {
        Debug.Log("me activo");
        this.gameObject.SetActive(t);
    }
}
