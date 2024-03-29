using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private Transform m_Target;
    [SerializeField] private Vector3 m_Offset;
    [SerializeField] private float m_RotateSpeed = 4f;
    [SerializeField] private float m_RadiusHorizontal;
    [SerializeField] private float m_RadiusVertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(m_Target);

        float vertical = Input.GetKey(KeyCode.UpArrow) ? 1 : 0;
        if (vertical == 0)
        {
            vertical = Input.GetKey(KeyCode.DownArrow) ? -1 : 0;
        }
        float horizontal = Input.GetKey(KeyCode.RightArrow) ? 1 : 0;
        if (horizontal == 0)
        {
            horizontal = Input.GetKey(KeyCode.LeftArrow) ? -1 : 0;
        }
        if (horizontal != 0)
        {
            m_RadiusHorizontal -= horizontal * Time.fixedDeltaTime * m_RotateSpeed;
        }
        if (vertical != 0)
        {
            m_RadiusVertical += vertical * Time.fixedDeltaTime * m_RotateSpeed;
        }


        transform.position = m_Target.position
            + Mathf.Cos(m_RadiusHorizontal) * new Vector3(1, 0, 0) * 10f
            + Mathf.Sin(m_RadiusHorizontal) * new Vector3(0, 0, 1) * 10
            + Mathf.Cos(m_RadiusVertical) * new Vector3(0, 1, 0) * 10f;
    }
}
