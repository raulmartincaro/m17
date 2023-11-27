using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static SaveData;

public class JugadorController : MonoBehaviour, ISaveableObject
{
    private enum SwitchMachinesStates { QUIET, NAVEGANT, INTERACTUANT, PESCANT,VENENT };
    private SwitchMachinesStates m_CurrentState;
    [SerializeField]
    private InputActionAsset m_InputAsset;
    private InputActionAsset m_Input;
    private InputAction m_MovementAction;
    private Rigidbody2D m_Rigidbody;
    private int m_Speed = 20;
    float maxSpeed = 3.0f;

    [SerializeField]
    BuscadorController m_BuscadorController;
    int m_objeto;

    [SerializeField]
    GameEventBoolean m_comprando;

    private void ChangeState(SwitchMachinesStates newState)
    {
        if (newState == m_CurrentState)
            return;
        ExitState();
        InitState(newState);
    }

    private void ExitState()
    {
        switch (m_CurrentState)
        {

            case SwitchMachinesStates.NAVEGANT:
                m_Rigidbody.velocity = Vector2.zero;

            break;

        }
    }

    private void InitState(SwitchMachinesStates currentState)
    {
        m_CurrentState = currentState;
        switch (m_CurrentState)
        {

            case SwitchMachinesStates.QUIET:
                m_Rigidbody.velocity = Vector2.zero;

                break;

            case SwitchMachinesStates.NAVEGANT:

                break;
            case SwitchMachinesStates.INTERACTUANT:
                m_BuscadorController.comprobarAlrededor();
                break;
            case SwitchMachinesStates.PESCANT:
                StartCoroutine(pescando());
                break;
            case SwitchMachinesStates.VENENT:
                m_comprando.Raise(true);
                break;

        }

    }

    private void UpdateState()
    {
        switch (m_CurrentState)
        {
            case SwitchMachinesStates.QUIET:
             
                if (m_MovementAction.ReadValue<Vector2>() != new Vector2(0, 0))
                {
                    ChangeState(SwitchMachinesStates.NAVEGANT);
                }

                break;
            case SwitchMachinesStates.NAVEGANT:
                m_Rigidbody.AddForce(m_MovementAction.ReadValue<Vector2>() * m_Speed);
                Vector2 clampedVelocity = Vector2.ClampMagnitude(m_Rigidbody.velocity, maxSpeed);
                m_Rigidbody.velocity = clampedVelocity;

                if (m_MovementAction.ReadValue<Vector2>() == new Vector2(0, 0))
                    ChangeState(SwitchMachinesStates.QUIET);
                break;
            case SwitchMachinesStates.INTERACTUANT:
                switch(m_objeto)
                {
                    case 0:
                        ChangeState(SwitchMachinesStates.QUIET);
                        break;
                    case 1:
                        ChangeState(SwitchMachinesStates.VENENT);
                    break;
                    case 2:
                        ChangeState(SwitchMachinesStates.PESCANT);
                    break;
                }


                break;

        }
    }


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Input = Instantiate(m_InputAsset);
        m_MovementAction = m_Input.FindActionMap("Player").FindAction("Move");
        m_Input.FindActionMap("Player").FindAction("Accion").performed += interactuar;
        m_Input.FindActionMap("Player").Enable();
    }

   
    void Start()
    {
        InitState(SwitchMachinesStates.QUIET);

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

    public void interactuar(InputAction.CallbackContext actionContext)
    {
        ChangeState(SwitchMachinesStates.INTERACTUANT);
    }

    public void queTengo(int n)
    {
        m_objeto = n;
    }
    IEnumerator pescando()
    {
        yield return new WaitForSeconds((float)1.5);

    }
}
