using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UIElements;
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

    private int m_LateralMovement;

    [SerializeField]
    private float m_MovementSpeed = 10f;
    private Boolean m_bolaActiva;

    private Vector3 m_PositionInicial;
    private Vector3 m_PosicionActual;
    private Vector3 m_MyScaleInicial;
    bool m_powerUp;
    float m_TimePowerUp;
    private void Awake()
    {
        m_Input = Instantiate(m_inputActions);

        m_Input.FindActionMap("Player").FindAction("Sacar").performed += Tirarpelota;
        m_MovementAction = m_Input.FindActionMap("Player").FindAction("Movimiento");
        m_PointerAction = m_Input.FindActionMap("Player").FindAction("PointerPosition");
      
        m_Input.FindActionMap("Player").Enable();
        m_PositionInicial =this.transform.position;
        m_MyScaleInicial = this.transform.localScale;
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_powerUp = false;

    }
    void Start()
    {
        m_bolaActiva = false;
    }
    void Update()
    {
        Vector2 delta = m_MovementAction.ReadValue<Vector2>();
        m_PosicionActual=this.transform.position;

        Vector3 m_mousePosition = m_PointerAction.ReadValue<Vector2>();
        Vector3 m_coordenadasMundo = Camera.main.ScreenToWorldPoint(m_mousePosition);
        //Debug.Log("mouse position: " + m_mousePosition);
        //Debug.Log("mundo position: " + m_coordenadasMundo);
        if (m_coordenadasMundo.x-0.1 > m_PosicionActual.x)
        {
            m_LateralMovement = 1;
        }
        else
        {

            if (m_coordenadasMundo.x+0.1 < m_PosicionActual.x)
            {
                m_LateralMovement = -1;
            }
            else
            {
                m_LateralMovement = 0;
            }
        }

        if (m_powerUp)
            m_TimePowerUp -= Time.deltaTime;
        
    }
    private void FixedUpdate()
    {
        m_Rigidbody.velocity = m_MovementSpeed * new Vector3(m_LateralMovement, 0, 0);
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

    private void OnDisable()
    {
        m_Input.FindActionMap("Player").FindAction("Sacar").performed -= Tirarpelota;
        StopCoroutine("poweeeer");

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Capsulas")
        {
            if(collision.gameObject.GetComponent<CapsuleController>().powerUp==true)
            {
                StopCoroutine(poweeeer());
                m_powerUp = false;
                m_TimePowerUp = 15f;
                StartCoroutine(poweeeer());
            }
        }  
    }
    IEnumerator poweeeer()
    {
        m_powerUp = true;
        transform.localScale =new Vector3 (2,0.2f,1);
        yield return new WaitForSeconds(m_TimePowerUp);
        transform.localScale = m_MyScaleInicial;
        m_powerUp = false;
    }
}
