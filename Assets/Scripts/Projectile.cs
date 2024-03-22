using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Timer m_LifeTimer;
    private Rigidbody m_Rigidbody;
    private bool m_IsDestroyed;

    private void Update()
    {
        m_LifeTimer.RunTimer();

        if (!m_LifeTimer.IsActive && !m_IsDestroyed)
        {
            Destroy(gameObject);

            m_IsDestroyed = true;
        }
    }
    public void Initialize(Vector3 velocity)
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.velocity = velocity;

        m_LifeTimer = new Timer(4f);
    }
}
