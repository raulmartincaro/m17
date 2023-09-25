using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngineInternal;

public class PlataformaController : MonoBehaviour
{

    [SerializeField]
    private GameObject m_pelota;
    [SerializeField]
    private InputActionAsset m_inputActions;
    private InputActionAsset m_Input;
    private InputAction m_MovementAction;

    [SerializeField]
    private float m_MovementSpeed = 3f;
    private Boolean m_bolaActiva;

    private Vector3 m_PositionInicial;
    private void Awake()
    {
        m_Input = Instantiate(m_inputActions);

        m_Input.FindActionMap("Player").FindAction("Sacar").performed += Tirarpelota;
        m_MovementAction = m_Input.FindActionMap("Player").FindAction("Movimiento");
        

        m_Input.FindActionMap("Player").Enable();
        m_PositionInicial=this.transform.position;

    }
    // Start is called before the first frame update
    void Start()
    {
        m_bolaActiva = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 delta = m_MovementAction.ReadValue<Vector2>();
       
        transform.position += m_MovementSpeed * new Vector3(delta.x, delta.y, 0) * Time.deltaTime;
    }

    private void Tirarpelota(InputAction.CallbackContext context)
    {
        if (!m_bolaActiva)
        {
            m_bolaActiva = true;
            Instantiate(m_pelota, this.transform.position, Quaternion.identity);
        }
    }
    public void muertepelota(int n)
    {
        m_bolaActiva = false;
        this.transform.position = m_PositionInicial;
    }


  
}
