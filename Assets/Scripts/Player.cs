using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float m_Speed = 1f;

    [SerializeField] private float m_JumpVelocity = 5f;
    private Rigidbody m_Rigidbody;
    private Transform m_Camera;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Camera = GameObject.Find("Camera").transform;
    }

    private void FixedUpdate()
    {
        float vertical = Input.GetKey(KeyCode.W) ? 1 : 0;
        if (vertical == 0)
        {
            vertical = Input.GetKey(KeyCode.S) ? -1 : 0;
        }
        float horizontal = Input.GetKey(KeyCode.D) ? 1 : 0;
        if (horizontal == 0)
        {
            horizontal = Input.GetKey(KeyCode.A) ? -1 : 0;
        }
        Quaternion rotation = m_Camera.rotation.normalized;
        rotation.x = 0;
        rotation.z = 0;
        m_Rigidbody.velocity = rotation * new Vector3(horizontal * m_Speed * Time.deltaTime, m_Rigidbody.velocity.y, vertical * m_Speed * Time.deltaTime);


    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            m_Rigidbody.velocity += Vector3.up * m_JumpVelocity;
        }
    }
}
