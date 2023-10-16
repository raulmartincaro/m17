using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

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
           

                break;

            default:
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


                Debug.Log("" + m_Rigidbody.velocity);
                if(m_Rigidbody.velocity ==Vector2.zero)
                    ChangeState(SwitchMachinesStates.IDLE);
                break;
            case SwitchMachinesStates.HIT1:
                break;
        }
    }

    private void ExitState()
    {
        //esto es para los combos ya lo tocaremos

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

            default:
                break;
        }
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


    void Awake()
    {
        m_Input = Instantiate(m_InputAsset);
        m_MovementAction = m_Input.FindActionMap("Tierra").FindAction("Movement");
        m_Input.FindActionMap("Tierra").FindAction("Attack").performed += AttackAction;
        m_Input.FindActionMap("Tierra").Enable();



        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();




    }


    // Start is called before the first frame update
    void Start()
    {
        InitState(SwitchMachinesStates.IDLE);

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

}
