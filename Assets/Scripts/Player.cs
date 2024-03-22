using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float m_Speed = 1f;

    [SerializeField] private float m_JumpVelocity = 5f;
    private Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Rigidbody.velocity = transform.rotation * new Vector3(horizontal * m_Speed, m_Rigidbody.velocity.y, vertical * m_Speed);


    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            m_Rigidbody.velocity += Vector3.up * m_JumpVelocity;
        }
    }
}
