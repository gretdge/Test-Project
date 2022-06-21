using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.CharacterController))]
public class UnityPlayerController : MonoBehaviour
{
    [SerializeField] private float m_playerSpeed = 2.0f;

    private UnityEngine.CharacterController m_controller;



    //private Vector3 m_playerVelocity;
    //private bool m_groundedPlayer;
    
    //private float m_jumpHeight = 1.0f;
    //private float m_gravityValue = -9.81f;

    private Vector3 move = Vector3.zero;

    private void Start()
    {
        m_controller = GetComponent<UnityEngine.CharacterController>();
    }

    void FixedUpdate()
    {
        float vertical = Input.GetAxis("VerticalMovement");
        float horizontal = Input.GetAxis("HorizontalMovement");

        move = Vector3.zero;
        move += transform.forward * vertical * m_playerSpeed * Time.fixedDeltaTime;
        move += transform.right * horizontal * m_playerSpeed * Time.fixedDeltaTime;
        move += Physics.gravity;

        m_controller.Move(move);

        //m_groundedPlayer = m_controller.isGrounded;
        //if (m_groundedPlayer && m_playerVelocity.y < 0)
        //{
        //    m_playerVelocity.y = 0f;
        //}

        //Vector3 move = new Vector3(Input.GetAxis("HorizontalMovement"), 0, Input.GetAxis("VerticalMovement"));
        //m_controller.Move(transform.InverseTransformDirection(Vector3.forward) * move * Time.deltaTime * m_playerSpeed);

        //Vector3 movement = Vector3.zero;
        //float v = Input.GetAxis("VerticalMovement");
        //float h = Input.GetAxis("HorizontalMovement");
        //movement += transform.forward * v * m_playerSpeed * Time.deltaTime;
        //movement += transform.right * h * m_playerSpeed * Time.deltaTime;
        //movement += Physics.gravity;
        //m_controller.Move(movement);

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        //m_playerVelocity.y += m_gravityValue * Time.deltaTime;
        //m_controller.Move(m_playerVelocity * Time.deltaTime);
    }
}
