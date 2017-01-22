using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    // Use this for initialization
    public Rigidbody2D m_RB;
    public float m_thrust;
    public float m_Time;
    public float m_lifetime;

    void Start()
    {
        m_RB = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        m_RB.AddForce(-transform.up * m_thrust);

        m_Time += 1.0f * Time.deltaTime;
        if (m_Time >= 1)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
