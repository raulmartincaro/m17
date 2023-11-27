using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
using static EnemyController;

public class CharacterController : MonoBehaviour
{
   
    private enum SwitchMachinesStates {NONE, IDLE, WALK, HIT1, HIT2};
    private SwitchMachinesStates m_CurrentState;

    private void ChangeState(SwitchMachinesStates newState)
    {
        if (newState == m_CurrentState)
            return;

        ExitState();
        InitState(newState);
    }

    private void InitState (SwitchMachinesStates currentState)
    {
        m_CurrentState = currentState;
        switch (m_CurrentState)
        {
            case SwitchMachinesStates.IDLE:
                m_Rigidbody.velocity = Vector2.zero;
                m_Animator.Play("Idle");

                break;

            case SwitchMachinesStates.WALK:
                m_Animator.Play("Correr");

                break;

            case SwitchMachinesStates.HIT1:

                m_Rigidbody.velocity = Vector2.zero;
                m_HitboxCharacter.Damage = m_Hit1Damage;
                m_Animator.Play("Pegar1");

                break;

            case SwitchMachinesStates.HIT2:

                m_Rigidbody.velocity = Vector2.zero;
                m_HitboxCharacter.Damage = m_Hit2Damage;
                m_Animator.Play("Pegar2");

                break;
        }

    }

    private void UpdateState()
    {
        switch (m_CurrentState)
        {

            case SwitchMachinesStates.IDLE:
                if(m_MovementAction.ReadValue<Vector2>()!= new Vector2(0, 0))
                {
                    ChangeState(SwitchMachinesStates.WALK);
                }

                break;
            case SwitchMachinesStates.WALK:
                m_Rigidbody.velocity= m_MovementAction.ReadValue<Vector2>() * m_Speed;

                if (m_Rigidbody.velocity.x < 0)
                {
                    m_Rigidbody.transform.eulerAngles = Vector3.up*180;
                }else if (m_Rigidbody.velocity.x > 0)
                {
                    m_Rigidbody.transform.eulerAngles = Vector3.zero;
                }

                if (m_Rigidbody.velocity ==Vector2.zero)
                    ChangeState(SwitchMachinesStates.IDLE);
                break;
            
        }
    }

    private void ExitState()
    {
        switch (m_CurrentState)
        {

            case SwitchMachinesStates.HIT1:

                m_ComboAvailable = false;

                break;

            case SwitchMachinesStates.HIT2:

                m_ComboAvailable = false;

                break;

            default:
                break;
        }


    }


    private void AttackAction(InputAction.CallbackContext actionContext)
    {
        switch (m_CurrentState)
        {
            case SwitchMachinesStates.IDLE:
                ChangeState(SwitchMachinesStates.HIT1);

                break;

            case SwitchMachinesStates.WALK:
                ChangeState(SwitchMachinesStates.HIT1);

                break;
            case SwitchMachinesStates.HIT1:

            if (m_ComboAvailable)
                ChangeState(SwitchMachinesStates.HIT2);
               

              break;


        }
    }


    public void InitComboWindow()
    {
        m_ComboAvailable = true;
    }

    public void EndComboWindow()
    {
        m_ComboAvailable = false;
    }


    public void EndHit()
    {
        ChangeState(SwitchMachinesStates.IDLE);
    }


    [SerializeField]
    private InputActionAsset m_InputAsset;

    private InputActionAsset m_Input;
    private InputAction m_MovementAction;
    private Animator m_Animator;
    private Rigidbody2D m_Rigidbody;

   



    [Header("Character Values")]
    [SerializeField]
    private float m_Speed = 3;
    [SerializeField]
    private int m_Hit1Damage = 2;
    [SerializeField]
    private int m_Hit2Damage = 5;
    private bool m_ComboAvailable;
    [SerializeField]
    private HitboxCharacter m_HitboxCharacter;
    [SerializeField]
    EstadisticsInfo m_vida;

    void Awake()
    {
        m_Input = Instantiate(m_InputAsset);
        m_MovementAction = m_Input.FindActionMap("Tierra").FindAction("Movement");
        m_Input.FindActionMap("Tierra").FindAction("Attack").performed += AttackAction;
        m_Input.FindActionMap("Tierra").Enable();



        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_vida.valorActual = 100;



    }


    // Start is called before the first frame update
    void Start()
    {
        InitState(SwitchMachinesStates.IDLE);
        m_ComboAvailable = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }
    private void OnDestroy()
    {
        m_Input.FindActionMap("Tierra").FindAction("Attack").performed -= AttackAction;
        m_Input.FindActionMap("Tierra").Disable();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemyHitBox")
        {
            m_vida.valorActual -= collision.gameObject.GetComponent<HitboxCharacter>().Damage;
           
            
        }
        if (collision.gameObject.tag == "Bala")
        {
            m_vida.valorActual -= collision.gameObject.GetComponent<BalaController>().damage;
           
            
        }
      

    }
}
