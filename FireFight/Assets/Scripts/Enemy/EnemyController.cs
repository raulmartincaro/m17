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
    GameObject m_objetivo;
    int m_vida;
    private Animator m_Animator;

    /*public delegate void EnemyDestroyed(GameObject go);
    public event EnemyDestroyed OnEnemyDestroyed;*/


    void Start()
    {
        m_deteccion= GetComponentInChildren<BuscadorController>();
        m_detectado = false;
        m_deteccionGolpeacion = GetComponentInChildren<GolpadorController>();
        m_golpeo = false;
        m_CurrentState = switchMachineStates.PATROL;
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator= GetComponent<Animator>();
        ChangeState(m_CurrentState);
        m_vida = 10;
    }

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
        //para orientar al bicho
        if (m_Rigidbody.velocity.x < 0)
        {
            m_Rigidbody.transform.eulerAngles = Vector3.up * 180;
        }
        else if (m_Rigidbody.velocity.x > 0)
        {
            m_Rigidbody.transform.eulerAngles = Vector3.zero;
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
            case switchMachineStates.PATROL:
                m_Animator.Play("Patrol");
                int dir = Random.Range(0, 2);
                if (dir == 0)
                {
                    m_Rigidbody.velocity = new Vector2(1, 0).normalized * 1*Time.deltaTime;
                }
                else
                {
                    m_Rigidbody.velocity = new Vector2(-1, 0).normalized * 1*Time.deltaTime;
                }
                break;
            case switchMachineStates.CHASE:
                m_Animator.Play("Chase");
                break;

            case switchMachineStates.ATTACK:
                m_Rigidbody.velocity=Vector2.zero;
                m_Animator.Play("Hit");
                break;
        }

    }
    private void UpdateState()
    {
        switch (m_CurrentState)
        {
            case switchMachineStates.PATROL:
                m_Rigidbody.velocity = new Vector2(1, 0).normalized * 1;
                if (m_detectado)
                {
                    ChangeState(switchMachineStates.CHASE);
                }
                break;
            case switchMachineStates.CHASE:
                m_Rigidbody.velocity = (m_objetivo.transform.position - m_Rigidbody.transform.position).normalized * 2;
               if (m_golpeo)
                   ChangeState(switchMachineStates.ATTACK);
                break;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerHitBox")
        {
            m_vida -= collision.gameObject.GetComponent<HitboxCharacter>().Damage;
            if (m_vida <= 0)
            {
                Destroy(this.gameObject);
                //OnEnemyDestroyed?.Invoke(gameObject);
            }
                
        }
        
    }

    private void puedoGolpear()
    {
        if (!m_deteccionGolpeacion.Golpeable == true)
        {
            m_golpeo = false;
            ChangeState(switchMachineStates.CHASE);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Me he comido la pared");
        if (collision.gameObject.tag == "pared" && m_CurrentState == switchMachineStates.PATROL)
        {
            m_Rigidbody.velocity *= -1;
        }
    }
}
