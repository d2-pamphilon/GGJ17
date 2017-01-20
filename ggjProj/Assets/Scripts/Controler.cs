using UnityEngine;
using System.Collections;

public class Controler : MonoBehaviour
{

    public Rigidbody2D m_rb;
    public Vector2 m_input;
    public float m_MoveSpeed;
    public bool m_buttonInput;
    public int m_Player;
    public GameObject m_SpawnLoc;

    // Use this for initialization
    void Start()
    {

        if (m_Player == 1)
        {
            m_SpawnLoc.transform.position = new Vector2(1, 0);
        }
        else
        {
            m_SpawnLoc.transform.position = new Vector2(-1, 0);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get buttins
        //rigidbody add force in analog direction
        if (m_Player == 1)
        {
            m_input = new Vector2(Input.GetAxis("LeftStickHorizontal") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("LeftStickVertical") * Time.deltaTime * m_MoveSpeed);
            //m_rb.AddForce(m_input * m_MoveSpeed);
            // m_input = m_input * m_MoveSpeed * Time.deltaTime;
            //transform.position = m_input;
            transform.Translate(m_input.x, m_input.y, 0);
        }
        else
        {
            m_input = new Vector2(Input.GetAxis("RightStickHorizontal") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("RightStickVertical") * Time.deltaTime * m_MoveSpeed);
            transform.Translate(m_input.x, m_input.y, 0);
            // m_input = m_input * m_MoveSpeed * Time.deltaTime;
            //transform.position = m_input;
            //m_rb.AddForce(m_input * m_MoveSpeed);
        }
        if (Input.GetButton("BackButton"))
        {
            print("button");
            if (m_Player == 1)
            {

                transform.position = new Vector2(1,0);
                transform.rotation = m_SpawnLoc.transform.rotation;
            }
            else
            {
                transform.position = new Vector2(-1, 0);
                transform.rotation = m_SpawnLoc.transform.rotation;
            }
        }
        if (Input.GetButton("ButtonA"))
        { print("A"); }
        if (Input.GetButton("ButtonB"))
        { print("B"); }
        if (Input.GetButton("ButtonX"))
        { print("X"); }
        if (Input.GetButton("ButtonY"))
        { print("Y"); }
        if (Input.GetAxis("LeftStickHorizontal") >=1)
        { print("LeftStickHorizontal"); }
        if (Input.GetAxis("LeftStickVertical")<=-1)
        { print("LeftStickVertical"); }
        if (Input.GetAxis("RightStickHorizontal") >= 1)
        { print("RightStickHorizontal"); }
        if (Input.GetAxis("RightStickVertical") <= -1)
        { print("RightStickVertical"); }
        if (Input.GetAxis("LeftButtonVertical") >= 1)
        { print("LeftButtonVertical"); }
        if (Input.GetAxis("LeftButtonHorizontal") <= -1)
        { print("LeftButtonHorizontal"); }
        if (Input.GetAxis("LeftButtonVertical") <= -1)
        { print("LeftButtonVertical"); }
        if (Input.GetAxis("LeftButtonHorizontal") >= 1)
        { print("LeftButtonHorizontal"); }




    }
}
