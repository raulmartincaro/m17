using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class EnemyControllerDisparador : MonoBehaviour
{

    private enum switchMachineStates { NONE, PATROL, ATTACK, RECARGANDO}
    [SerializeField]
    private switchMachineStates m_CurrentState;
    BuscadorController m_detector;
    public Rigidbody2D m_Rigidbody;
    GameObject m_objetivo;
    int m_vida;
    private Animator m_Animator;
    private Vector2 m_movement;
    public int m_velocity=0;
    int m_damage;
    [SerializeField]
    BalaController m_bala;

    public delegate void EnemyRangedDestroyed(GameObject go);
    public event EnemyRangedDestroyed OnEnemyRangedDestroyed;


    void Start()
    {
        m_detector = GetComponentInChildren<BuscadorController>();
        m_CurrentState = switchMachineStates.PATROL;
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        ChangeState(m_CurrentState);
        m_vida = 10;
        int dir = Random.Range(0, 2);
        if (dir == 0)
        {
            m_movement = new Vector2(1, 0);
        }
        else
        {
            m_movement = new Vector2(-1, 0);
        }
        m_velocity = 2;


    }

    void Update()
    {

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

                break;
            case switchMachineStates.ATTACK:
                m_Rigidbody.velocity = Vector2.zero;
                if (m_Rigidbody.position.x > m_objetivo.transform.position.x)
                {
                    m_Rigidbody.transform.eulerAngles = Vector3.zero;
                }
                else
                {
                    m_Rigidbody.transform.eulerAngles = Vector3.up * 180;

                }

                Disparo();
                break;
            case switchMachineStates.RECARGANDO:
                m_Rigidbody.velocity = Vector2.zero;
                m_Animator.Play("Cargar");
                break;
        }

    }
    private void UpdateState()
    {


        if (m_detector.Encontrado)
        {
            m_objetivo = GetComponentInChildren<BuscadorController>().m_objetivo;

        }

        //para orientar al bicho
        if (m_Rigidbody.velocity.x < 0)
        {
            m_Rigidbody.transform.eulerAngles = Vector3.zero;

        }
        else if (m_Rigidbody.velocity.x > 0)
        {
            m_Rigidbody.transform.eulerAngles = Vector3.up * 180;
        }

        switch (m_CurrentState)
        {
            case switchMachineStates.PATROL:
                Debug.Log("velocidad: " + m_Rigidbody.velocity);
                if (m_Rigidbody.velocity.x < 2 && m_Rigidbody.velocity.x>-2)
                    m_Rigidbody.AddForce(m_movement * m_velocity);
                if (m_detector.Encontrado)
                {
                    ChangeState(switchMachineStates.RECARGANDO);
                }
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
                OnEnemyRangedDestroyed?.Invoke(gameObject);
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pared") && m_CurrentState == switchMachineStates.PATROL)
        {
            m_Rigidbody.transform.eulerAngles = Vector3.zero;
            m_movement *= -1;
        }
    }

    public void RecargaLista()
    {
        ChangeState(switchMachineStates.ATTACK);
    }

    public void Disparo()
    {
        m_bala.m_dir = m_objetivo.transform.position;
        BalaController proyectil =Instantiate(m_bala,this.m_Rigidbody.transform.position, Quaternion.identity);
        proyectil.damage = m_damage;
        if (m_detector.Encontrado == false)
        {
            Debug.Log("lo he perdido");
            m_objetivo = null;
            ChangeState(switchMachineStates.PATROL);
        }
        else
        {
            ChangeState(switchMachineStates.RECARGANDO);
        }
    }

    public void LoadInfo(EnemyInfo enemyinfo)
    {
        GetComponent<SpriteRenderer>().color= enemyinfo.color;
        m_velocity = enemyinfo.velocity;
        m_damage = enemyinfo.damage;

    }

}