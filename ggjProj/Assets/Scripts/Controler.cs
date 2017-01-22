using UnityEngine;
using System.Collections;

public class Controler : MonoBehaviour
{

    public Rigidbody2D m_rb;

    public GameObject m_bullet;
    public Vector2 m_baseInput;
    public Vector2 m_turretInput;
    public float m_MoveSpeed;
    public bool m_buttonInput;
    // public int m_Player;

    public GameObject m_SpawnLoc;
    public GameStates _GS;
    public GameStates.State m_PS;
    private Player m_player;

    public float m_TempValY = 0f;
    public float m_TempValX = 0f;
    public float angle;
    public float m_chAngle;

    public Vector2 trigger;


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

        trigger = new Vector2(Input.GetAxis("LeftButtonVertical"), Input.GetAxis("LeftButtonHorizontal"));


        /*     if (Input.GetAxis("LeftStickHorizontalP1") >= 1)
             { print("LeftStickHorizontal1"); }
             if (Input.GetAxis("LeftStickVerticalP1") <= -1)
             { print("LeftStickVertical1"); }
             if (Input.GetAxis("LeftStickHorizontalP2") >= 1)
             { print("LeftStickHorizontal2"); }
             if (Input.GetAxis("LeftStickVerticalP2") <= -1)
             { print("LeftStickVertical2"); }
             /*  if (Input.GetButton("ButtonAP1"))
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
               { print("Y2"); }*/

    }

    void OneControl()
    {
        ABXYButtonP1();
        TurretAimP1();

        print("one control");

        /*  if (Input.GetAxis("BackTriggerLeftP1") <= -1)
          { print("Trigger1"); }
          if (Input.GetAxis("BackTriggerRightP1") <= -1)
          { print("Trigger1"); }
          if (Input.GetAxis("BackTriggerLeftP2") <= -1)
          { print("2Trigger"); }
          if (Input.GetAxis("BackTriggerRightP2") <= -1)
          { print("2Trigger1"); }*/



        // m_baseInput = new Vector2(Input.GetAxis("LeftStickHorizontalP1") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("LeftStickVerticalP1") * Time.deltaTime * m_MoveSpeed);
        // transform.Translate(m_baseInput.x, m_baseInput.y, 0);
        /* print(m_baseInput);
         m_turretInput = new Vector3(Input.GetAxis("RightStickHorizontal") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("RightStickHorizontal") * Time.deltaTime * m_MoveSpeed,0);
         turretMag = m_turretInput.magnitude;
         transform.rotation = new Quaternion(m_turretInput.x, -m_turretInput.y, 0, 0); //(m_turretInput.x, m_turretInput.y, 0);*/



    }

    void TwoPlayTwoCon()
    {

        switch (m_PS)
        {
            case GameStates.State.GS_PLAYER1:
                print("Player1");
                ABXYButtonP1();
                TurretAimP1();

                /* m_baseInput = new Vector2(Input.GetAxis("LeftStickHorizontalP1") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("LeftStickVerticalP1") * Time.deltaTime * m_MoveSpeed);
                 transform.Translate(m_baseInput.x, m_baseInput.y, 0);
                 m_turretInput = new Vector2(Input.GetAxis("RightStickHorizontal") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("RightStickHorizontal") * Time.deltaTime * m_MoveSpeed);
                 turretMag = m_turretInput.magnitude;*/
                break;
            case GameStates.State.GS_PLAYER2:
                print("player2");
                ABXYButtonP2();
                TurretAimP2();

                /*m_baseInput = new Vector2(Input.GetAxis("LeftStickHorizontalP2") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("LeftStickVerticalP2") * Time.deltaTime * m_MoveSpeed);
                transform.Translate(m_baseInput.x, m_baseInput.y, 0);
                m_turretInput = new Vector2(Input.GetAxis("RightStickHorizontal") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("RightStickHorizontal") * Time.deltaTime * m_MoveSpeed);
                turretMag = m_turretInput.magnitude;*/
                break;
        }
    }
    void TwoPlayOneCon()
    {
        switch (m_PS)
        {
            case GameStates.State.GS_PLAYER1:
                print("Player1HC");
                //sticj for rotation, buttons for movement
                TurretAimP1HC();
                DPad();

                /*m_baseInput = new Vector2(Input.GetAxis("LeftStickHorizontalP1") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("LeftStickVerticalP1") * Time.deltaTime * m_MoveSpeed);
                transform.Translate(m_baseInput.y, m_baseInput.x, 0);*/
                break;
            case GameStates.State.GS_PLAYER2:
                TurretAimP2HC();
                ABXYHC();
                print("player2HC");
               /* m_baseInput = new Vector2(Input.GetAxis("RightStickHorizontal") * Time.deltaTime * m_MoveSpeed, Input.GetAxis("RightStickVertical") * Time.deltaTime * m_MoveSpeed);
                transform.Translate(-m_baseInput.y, m_baseInput.x, 0);*/
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


    void ABXYButtonP1()
    {
        if (Input.GetButton("ButtonAP1"))
        {
            print("A Buttton");
            m_TempValY = -1f;
        }
        else if (Input.GetButton("ButtonBP1"))
        {
            print("B Buttton");
            m_TempValX = 1f;
        }
        else if (Input.GetButton("ButtonXP1"))
        {
            print("X Buttton");
            m_TempValX = -1f;
        }
        else if (Input.GetButton("ButtonYP1"))
        {
            print("Y Buttton");
            m_TempValY = 1f;
        }
        else
        {
            m_TempValY = 0f;
            m_TempValX = 0f;
        }

        m_baseInput = new Vector2(m_TempValX * Time.deltaTime * m_MoveSpeed, m_TempValY * Time.deltaTime * m_MoveSpeed);
        transform.Translate(m_baseInput, 0);

        /*m_TempValY = 0f;
        m_TempValX = 0f;*/
    }
    void ABXYButtonP2()
    {
        if (Input.GetButton("ButtonAP2"))
        {
            print("2A Buttton");
            m_TempValY = -1f;
        }
        else if (Input.GetButton("ButtonBP2"))
        {
            print("2B Buttton");
            m_TempValX = 1f;
        }
        else if (Input.GetButton("ButtonXP2"))
        {
            print("2X Buttton");
            m_TempValX = -1f;
        }
        else if (Input.GetButton("ButtonYP2"))
        {
            print("2Y Buttton");
            m_TempValY = 1f;
        }
        else
        {
            m_TempValY = 0f;
            m_TempValX = 0f;
        }

        m_baseInput = new Vector2(m_TempValX * Time.deltaTime * m_MoveSpeed, m_TempValY * Time.deltaTime * m_MoveSpeed);
        transform.Translate(m_baseInput, 0);

        /*m_TempValY = 0f;
        m_TempValX = 0f;*/
    }
    void DPad()
    {
        if (Input.GetAxis("LeftButtonVertical") ==1)
        {
            print("2A Buttton");
            m_TempValX = 1f;
        }
        else if (Input.GetAxis("LeftButtonVertical") == -1)
        {
            print("2B Buttton");
            m_TempValX = -1f;
        }
        else if (Input.GetAxis("LeftButtonHorizontal") == 1)
        {
            print("2X Buttton");
            m_TempValY =  1f;
        }
        else if (Input.GetAxis("LeftButtonHorizontal") == -1)
        {
            print("2Y Buttton");
            m_TempValY = -1f;
        }
        else
        {
            m_TempValY = 0f;
            m_TempValX = 0f;
        }

        m_baseInput = new Vector2(m_TempValX * Time.deltaTime * m_MoveSpeed, m_TempValY * Time.deltaTime * m_MoveSpeed);
        transform.Translate(m_baseInput, 0);
    }
    void ABXYHC()
    {
        if (Input.GetButton("ButtonAP1"))
        {
            print("2A Buttton");
            m_TempValX = -1f;
        }
        else if (Input.GetButton("ButtonBP1"))
        {
            print("2B Buttton");
            m_TempValY = -1f;
        }
        else if (Input.GetButton("ButtonXP1"))
        {
            print("2X Buttton");
            m_TempValY = 1f;
        }
        else if (Input.GetButton("ButtonYP1"))
        {
            print("2Y Buttton");
            m_TempValX = 1f;
        }
        else
        {
            m_TempValY = 0f;
            m_TempValX = 0f;
        }

        m_baseInput = new Vector2(m_TempValX * Time.deltaTime * m_MoveSpeed, m_TempValY * Time.deltaTime * m_MoveSpeed);
        transform.Translate(m_baseInput, 0);

        /*m_TempValY = 0f;
        m_TempValX = 0f;*/
    }

    void TurretAimP1()
    {
        Vector2 input = new Vector2(
            Input.GetAxis("LeftStickHorizontalP1") * Time.deltaTime * m_MoveSpeed,
            Input.GetAxis("LeftStickVerticalP1") * Time.deltaTime * m_MoveSpeed);

        if (input != Vector2.zero)
        {
            //float vertical = Input.GetAxis("LeftStickVerticalP1") * Time.deltaTime * m_MoveSpeed);

            angle = Mathf.Atan2(input.x, -input.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

           
            if (Input.GetButton("BackButtonLeft"))
            {
                print("Bullet");
                Instantiate(m_bullet, transform.position, transform.rotation);
            }
        }


    }
    void TurretAimP2()
    {
        Vector2 input = new Vector2(
            Input.GetAxis("LeftStickHorizontalP2") * Time.deltaTime * m_MoveSpeed,
            Input.GetAxis("LeftStickVerticalP2") * Time.deltaTime * m_MoveSpeed);

        if (input != Vector2.zero)
        {
            //float vertical = Input.GetAxis("LeftStickVerticalP1") * Time.deltaTime * m_MoveSpeed);

            angle = Mathf.Atan2(input.x, -input.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            
            if (Input.GetButton("BackButtonLeft"))
            {
                print("Bullet");
                Instantiate(m_bullet, transform.position, transform.rotation);
            }
        }
    }

    void TurretAimP1HC()
    {
        Vector2 input = new Vector2(
           Input.GetAxis("LeftStickHorizontalP1") * Time.deltaTime * m_MoveSpeed,
           Input.GetAxis("LeftStickVerticalP1") * Time.deltaTime * m_MoveSpeed);

        if (input != Vector2.zero)
        {
            //float vertical = Input.GetAxis("LeftStickVerticalP1") * Time.deltaTime * m_MoveSpeed);

            angle = Mathf.Atan2(input.x, -input.y) * Mathf.Rad2Deg ;
            transform.rotation = Quaternion.Euler(new Vector3(0,0, angle + m_chAngle));
           
            if (Input.GetButton("BackButtonLeft"))
            {
                print("Bullet");
                Instantiate(m_bullet, transform.position, transform.rotation);
            }
        }
    }


   void TurretAimP2HC()
    {
        Vector2 input = new Vector2(
          Input.GetAxis("RightStickHorizontal") * Time.deltaTime * m_MoveSpeed,
          Input.GetAxis("RightStickVertical") * Time.deltaTime * m_MoveSpeed);

        if (input != Vector2.zero)
        {
            //float vertical = Input.GetAxis("LeftStickVerticalP1") * Time.deltaTime * m_MoveSpeed);

            angle = Mathf.Atan2(input.x, -input.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + m_chAngle));

            if (Input.GetButton("BackButtonRight"))
            {
                print("Bullet");
                Instantiate(m_bullet, transform.position, transform.rotation);
            }
        }
    }






}



//for bullet tag as bullet
