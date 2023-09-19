using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlataformaController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_pelota;
    [SerializeField]
    private InputActionAsset m_inputActions;
    private InputActionAsset m_Input;

    private void Awake()
    {
        m_Input = Instantiate(m_inputActions);

        m_Input.FindActionMap("Player").FindAction("Sacar").performed += Tirarpelota;

        

        m_Input.FindActionMap("Player").Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Tirarpelota(InputAction.CallbackContext context)
    {
        Instantiate(m_pelota, this.transform.position, Quaternion.identity);
    }
}
