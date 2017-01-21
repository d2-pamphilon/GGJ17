using UnityEngine;
using System.Collections;

public class Controler : MonoBehaviour
{

    public Rigidbody2D m_rb;
    public Vector2 m_input;
    public float m_MoveSpeed;
    public bool m_buttonInput;
    // public int m_Player;
    public GameObject m_SpawnLoc;
    public GameStates _GS;
    public GameStates.State m_PS;
    private Player m_player;

    // Use this for initialization
    void Start()
    {
        m_player = GetComponent<Player>();
    }


    void FixedUpdate()
    {
        if (Input.GetButton("BackButton")) // debug set both players back to the centre
        {
            switch (m_PS)
            {
                case GameStates.State.GS_PLAYER1:
                    transform.position = new Vector2(1, 0);
                    transform.rotation = m_SpawnLoc.transform.rotation;
                    break;
                case GameStates.State.GS_PLAYER2:
                    transform.position = new Vector2(-1, 0);
                    transform.rotation = m_SpawnLoc.transform.rotation;
                    break;
            }
        }

        m_PS = m_player.GetPlayerState();

        switch (_GS.getPlayState())
        {
            case GameStates.State.GS_1PLAYER:
                OneControl(); //1 controlls
                break;
            case GameStates.State.GS_2PLAYER: //goes intto switch
                switch (_GS.getDificulState())
                {
                    case GameStates.State.GS_EASYMODE:
                        TwoPlayTwoCon(); //2 players 2 controlls
                        break;
                    case GameStates.State.GS_HARDMODE:
                        TwoPlayOneCon(); // 2 player 1 controlls
                        break;
                }
                break;
        }
    }

    void OneControl()
    {
        print("one control");
        m_input = new Vector2(Input.GetAxis("LeftStickHorizontalP1") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("LeftStickVerticalP1") * Time.deltaTime * m_MoveSpeed);
        transform.Translate(m_input.x, m_input.y, 0);
    }

    void TwoPlayTwoCon()
    {

        switch (m_PS)
        {
            case GameStates.State.GS_PLAYER1:
                print("Player1");
                m_input = new Vector2(Input.GetAxis("LeftStickHorizontalP1") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("LeftStickVerticalP1") * Time.deltaTime * m_MoveSpeed);
                transform.Translate(m_input.x, m_input.y, 0);
                break;
            case GameStates.State.GS_PLAYER2:
                print("player2");
                m_input = new Vector2(Input.GetAxis("LeftStickHorizontalP2") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("LeftStickVerticalP2") * Time.deltaTime * m_MoveSpeed);
                transform.Translate(m_input.x, m_input.y, 0);
                break;
        }
    }
    void TwoPlayOneCon()
    {
        switch (m_PS)
        {
            case GameStates.State.GS_PLAYER1:
                print("Player1HC");
                m_input = new Vector2(Input.GetAxis("LeftStickHorizontalP1") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("LeftStickVerticalP1") * Time.deltaTime * m_MoveSpeed);
                transform.Translate(m_input.y, m_input.x, 0);
                break;
            case GameStates.State.GS_PLAYER2:
                print("player2HC");
                m_input = new Vector2(Input.GetAxis("RightStickHorizontal") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("RightStickVertical") * Time.deltaTime * m_MoveSpeed);
                transform.Translate(-m_input.y, m_input.x, 0);
                break;
        }
    }

    /*if (m_Player == 1)
    {
        m_input = new Vector2(Input.GetAxis("LeftStickHorizontalP1") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("LeftStickVerticalP1") * Time.deltaTime * m_MoveSpeed);
        //m_rb.AddForce(m_input * m_MoveSpeed);
        // m_input = m_input * m_MoveSpeed * Time.deltaTime;
        //transform.position = m_input;
        transform.Translate(m_input.x, m_input.y, 0);
    }
    else
    {
        m_input = new Vector2(Input.GetAxis("LeftStickHorizontalP2") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("LeftStickVerticalP2") * Time.deltaTime * m_MoveSpeed);
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

            transform.position = new Vector2(1, 0);
            transform.rotation = m_SpawnLoc.transform.rotation;
        }
        else
        {
            transform.position = new Vector2(-1, 0);
            transform.rotation = m_SpawnLoc.transform.rotation;
        }
    }
    if (Input.GetButton("ButtonAP1"))
    { print("A1"); }
    if (Input.GetButton("ButtonBP1"))
    { print("B1"); }
    if (Input.GetButton("ButtonXP1"))
    { print("X1"); }
    if (Input.GetButton("ButtonYP1"))
    { print("Y1"); }
    if (Input.GetButton("ButtonAP2"))
    { print("A2"); }
    if (Input.GetButton("ButtonBP2"))
    { print("B2"); }
    if (Input.GetButton("ButtonXP2"))
    { print("X2"); }
    if (Input.GetButton("ButtonYP2"))
    { print("Y2"); }
    if (Input.GetButton("BackButtonLeft"))
    { print("BL"); }
    if (Input.GetButton("BackButtonRight"))
    { print("BR"); }

    if (Input.GetAxis("LeftStickHorizontalP1") >= 1)
    { print("LeftStickHorizontal1"); }
    if (Input.GetAxis("LeftStickVerticalP1") <= -1)
    { print("LeftStickVertical1"); }
    if (Input.GetAxis("LeftStickHorizontalP2") >= 1)
    { print("LeftStickHorizontal2"); }
    if (Input.GetAxis("LeftStickVerticalP2") <= -1)
    { print("LeftStickVertical2"); }
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
    if (Input.GetAxis("BackTriggerLeftP1") <= -1)
    { print("Trigger"); }
    if (Input.GetAxis("BackTriggerRightP1") <= -1)
    { print("Trigger1"); }
    if (Input.GetAxis("BackTriggerLeftP2") <= -1)
    { print("Trigger"); }
    if (Input.GetAxis("BackTriggerRightP2") <= -1)
    { print("Trigger1"); }*/


}
