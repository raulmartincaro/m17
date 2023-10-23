using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static EnemyController;

public class EnemyController : MonoBehaviour
{
    private enum switchMachineStates {NONE,PATROL,CHASE,ATTACK}
    [SerializeField]
    private switchMachineStates m_CurrentState;
    BuscadorController m_deteccion;
    bool m_detectado;
    GolpadorController m_deteccionGolpeacion;
    bool m_golpeo;
    Rigidbody2D m_Rigidbody;
    public bool m_cooldown;
    [SerializeField]
    GameObject m_objetivo;
  
    void Start()
    {
        m_deteccion= GetComponentInChildren<BuscadorController>();
        m_detectado = false;
        m_deteccionGolpeacion = GetComponentInChildren<GolpadorController>();
        m_golpeo = false;
        m_CurrentState = switchMachineStates.PATROL;
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_cooldown = false;
        ChangeState(m_CurrentState);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_deteccion.Encontrado)
        {
            m_objetivo = GetComponentInChildren<BuscadorController>().m_objetivo;
            m_detectado = true;

        }
        if(m_deteccionGolpeacion.Golpeable)
        {
            m_golpeo = true;
        }

        UpdateState();

    }



    private void ChangeState(switchMachineStates newState)
    {
        if (newState == m_CurrentState)
            return;

        InitState(newState);
    }

    private void InitState(switchMachineStates currentState)
    {
        m_CurrentState = currentState;
        switch (m_CurrentState)
        {
           
            case switchMachineStates.ATTACK:
                m_Rigidbody.velocity=Vector2.zero;
                if (!m_cooldown)
                {
                    Debug.Log("Pego al jugador");
                }
                StartCoroutine("noPuedoGolpear");

                break;
        }

    }
    private void UpdateState()
    {
        switch (m_CurrentState)
        {
            case switchMachineStates.PATROL:
                Debug.Log("Estoy patrullando");
                if (m_detectado)
                {
                    
                    ChangeState(switchMachineStates.CHASE);
                }

                break;
            case switchMachineStates.CHASE:
                Debug.Log("Estoy buscando al jugador");
                m_Rigidbody.velocity = (m_objetivo.transform.position - m_Rigidbody.transform.position).normalized * 2;
                if (m_golpeo)
                   ChangeState(switchMachineStates.ATTACK);
                break;
            case switchMachineStates.ATTACK:
               
                ChangeState(switchMachineStates.CHASE);
                
                break;

        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerHitBox")
        {
            Debug.Log("Me han hecho un total de "+ collision.gameObject.GetComponent<HitboxCharacter>().Damage+" daño.");
        }
    }

    IEnumerator noPuedoGolpear()
    {
        m_cooldown = true;
        new WaitForSeconds(1);
        if (m_deteccionGolpeacion)
        {
            m_cooldown = false;
        }
        
        ChangeState(switchMachineStates.CHASE);
        return null;
    }
}
