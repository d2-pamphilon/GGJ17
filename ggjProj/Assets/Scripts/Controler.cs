using UnityEngine;
using System.Collections;

public class Controler : MonoBehaviour
{

    public Rigidbody2D m_rb;

    public GameObject m_bullet;
    public Vector2 m_baseInput;
    public Vector2 m_turretInput;
    public float m_MoveSpeed;
    // public int m_Player;

    private GameObject m_SpawnLoc;

    private GameObject m_GameState;
    private GameStates _GS;
    public GameStates.State m_Gs;
    public GameStates.State m_PS;

    private GameObject m_PlayerObject;
    public Player m_player;

    public float m_TempValY = 0f;
    public float m_TempValX = 0f;
    public float angle;
    public float m_chAngle;


    // Use this for initialization
    void Start()
    {

        m_GameState = GameObject.FindGameObjectWithTag("GameStateSystem");
        _GS = m_GameState.GetComponent<GameStates>();

       // m_PlayerObject = GameObject.FindGameObjectWithTag("Player");
        m_player = GetComponent<Player>();

        m_SpawnLoc = GetComponent<GameObject>();
       

    }


    void Update()
    {
        m_PS = m_player.GetPlayerState();
        m_Gs = _GS.getPlayState();
        print(m_Gs);
        print("hi");

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
            default: _GS.SetGameState(GameStates.State.GS_PLAYER, GameStates.State.GS_1PLAYER);
                break;
        }
    }

    void OneControl()
    {
        ABXYButtonP1();
        TurretAimP1();
    }

    void TwoPlayTwoCon()
    {
        switch (m_PS)
        {
            case GameStates.State.GS_PLAYER1:
                ABXYButtonP1();
                TurretAimP1();
                break;
            case GameStates.State.GS_PLAYER2:
                ABXYButtonP2();
                TurretAimP2();
                break;
        }
    }
    void TwoPlayOneCon()
    {
        switch (m_PS)
        {
            case GameStates.State.GS_PLAYER1:
                TurretAimP1HC();
                DPad();
                break;
            case GameStates.State.GS_PLAYER2:
                TurretAimP2HC();
                ABXYHC();
                break;
        }
    }


    void ABXYButtonP1()
    {
        if (Input.GetButton("ButtonAP1"))
        {
           
            m_TempValY = -1f;
        }
        else if (Input.GetButton("ButtonBP1"))
        {
            
            m_TempValX = 1f;
        }
        else if (Input.GetButton("ButtonXP1"))
        {
           
            m_TempValX = -1f;
        }
        else if (Input.GetButton("ButtonYP1"))
        {
           
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
            
            m_TempValY = -1f;
        }
        else if (Input.GetButton("ButtonBP2"))
        {
            
            m_TempValX = 1f;
        }
        else if (Input.GetButton("ButtonXP2"))
        {
            
            m_TempValX = -1f;
        }
        else if (Input.GetButton("ButtonYP2"))
        {
          
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
        if (Input.GetAxis("LeftButtonVertical") == 1)
        {
           
            m_TempValX = 1f;
        }
        else if (Input.GetAxis("LeftButtonVertical") == -1)
        {
          
            m_TempValX = -1f;
        }
        else if (Input.GetAxis("LeftButtonHorizontal") == 1)
        {
           
            m_TempValY = 1f;
        }
        else if (Input.GetAxis("LeftButtonHorizontal") == -1)
        {
           
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
            m_TempValX = -1f;
        }
        else if (Input.GetButton("ButtonBP1"))
        {
            m_TempValY = -1f;
        }
        else if (Input.GetButton("ButtonXP1"))
        {
            m_TempValY = 1f;
        }
        else if (Input.GetButton("ButtonYP1"))
        {
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
            angle = Mathf.Atan2(input.x, -input.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + m_chAngle));

            if (Input.GetButton("BackButtonLeft"))
            {
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
            angle = Mathf.Atan2(input.x, -input.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + m_chAngle));

            if (Input.GetButton("BackButtonRight"))
            {
                Instantiate(m_bullet, transform.position, transform.rotation);
            }
        }
    }


}



//for bullet tag as bullet
