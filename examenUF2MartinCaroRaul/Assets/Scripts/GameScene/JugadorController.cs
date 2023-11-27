using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static SaveData;

public class JugadorController : MonoBehaviour, ISaveableObject
{
    private enum SwitchMachinesStates { NONE, IDLE, WALK };
    private SwitchMachinesStates m_CurrentState;
    [SerializeField]
    private InputActionAsset m_InputAsset;
    private InputActionAsset m_Input;
    private InputAction m_MovementAction;
    private Rigidbody2D m_Rigidbody;
    private int m_Speed = 20;
    float maxSpeed = 3.0f;

    private void ChangeState(SwitchMachinesStates newState)
    {
        if (newState == m_CurrentState)
            return;
        ExitState();
        InitState(newState);
    }

    private void ExitState()
    {

    }

    private void InitState(SwitchMachinesStates currentState)
    {
        m_CurrentState = currentState;
        switch (m_CurrentState)
        {

            case SwitchMachinesStates.IDLE:
                m_Rigidbody.velocity = Vector2.zero;

                break;

            case SwitchMachinesStates.WALK:

                break;

        }

    }

    private void UpdateState()
    {
        switch (m_CurrentState)
        {
            case SwitchMachinesStates.IDLE:
             
                if (m_MovementAction.ReadValue<Vector2>() != new Vector2(0, 0))
                {
                    ChangeState(SwitchMachinesStates.WALK);
                }

                break;
            case SwitchMachinesStates.WALK:
                m_Rigidbody.AddForce(m_MovementAction.ReadValue<Vector2>() * m_Speed);
                Vector2 clampedVelocity = Vector2.ClampMagnitude(m_Rigidbody.velocity, maxSpeed);
                m_Rigidbody.velocity = clampedVelocity;

                if (m_MovementAction.ReadValue<Vector2>() == new Vector2(0, 0))
                    ChangeState(SwitchMachinesStates.IDLE);
                break;

        }
    }


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Input = Instantiate(m_InputAsset);
        m_MovementAction = m_Input.FindActionMap("Player").FindAction("Move");
        m_Input.FindActionMap("Player").Enable();
    }

   
    void Start()
    {
        InitState(SwitchMachinesStates.IDLE);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    public void Load(PlayerData _playerData)
    {
        throw new System.NotImplementedException();
    }

    public PlayerData Save()
    {
        throw new System.NotImplementedException();
    }

}
