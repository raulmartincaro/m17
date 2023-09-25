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
    private InputAction m_PointerAction;

    private Rigidbody2D m_Rigidbody;

    [SerializeField]
    private float m_MovementSpeed = 10f;
    private Boolean m_bolaActiva;

    private Vector3 m_PositionInicial;
    private void Awake()
    {
        m_Input = Instantiate(m_inputActions);

        m_Input.FindActionMap("Player").FindAction("Sacar").performed += Tirarpelota;
        m_MovementAction = m_Input.FindActionMap("Player").FindAction("Movimiento");
        m_PointerAction = m_Input.FindActionMap("Player").FindAction("PointerPosition");
      
        m_Input.FindActionMap("Player").Enable();
        m_PositionInicial =this.transform.position;
        m_Rigidbody = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        m_bolaActiva = false;
        
    }
    void Update()
    {
        Vector2 delta = m_MovementAction.ReadValue<Vector2>();
        m_Rigidbody.velocity = (m_MovementSpeed * new Vector3(delta.x, 0, 0) * Time.deltaTime).normalized;
        
        
        Vector3 m_mousePosition = m_PointerAction.ReadValue<Vector2>();
        Vector3 m_coordenadasMundo = Camera.main.ScreenToWorldPoint(m_mousePosition).normalized;
        Debug.Log("mouse position: " + m_mousePosition);
        Debug.Log("mundo position: " + m_coordenadasMundo);

        m_Rigidbody.velocity = (m_MovementSpeed * new Vector3(delta.x, 0, 0) * Time.deltaTime).normalized;
        
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

    public void moverMouse(InputAction.CallbackContext context)
    {

        


    }

}
