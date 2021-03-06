using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController m_controller;
    private Vector3 m_directionMovement;
    private float m_directionRotate;

    private void Start()
    {
        m_controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        m_directionMovement = new Vector3(Input.GetAxis("HorizontalMovement"), 0, Input.GetAxis("VerticalMovement"));
        m_directionRotate = Input.GetAxis("HorizontalRotate");

        m_controller.SetMovement(m_directionMovement);
        m_controller.SetRotate(m_directionRotate);

        if (Input.GetButtonDown("Shooting"))
        {
            m_controller.SetShooting();    
        }
    }
}
