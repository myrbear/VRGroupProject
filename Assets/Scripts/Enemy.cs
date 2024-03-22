using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject m_ProjectilePrefab;
    private float m_ProjectileSpeed = 4f;
    private Player m_Target;
    private Timer m_AttackTimer;

    private void Start()
    {
        m_Target = GameObject.Find("Player").GetComponent<Player>();
        m_AttackTimer = new Timer(0.5f);
    }
    private void Update()
    {
        transform.LookAt(m_Target.transform);

        m_AttackTimer.RunTimer();

        if (!m_AttackTimer.IsActive)
        {
            Shoot();

            m_AttackTimer.ResetTimer();
        }
    }
    public void Shoot()
    {
        GameObject clone = GameObject.Instantiate(m_ProjectilePrefab, transform.position, Quaternion.identity);
        Projectile projectile = clone.GetComponent<Projectile>();

        projectile.Initialize(transform.forward * m_ProjectileSpeed);
    }
}