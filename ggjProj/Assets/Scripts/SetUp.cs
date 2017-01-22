using UnityEngine;
using System.Collections;

public class SetUp : MonoBehaviour
{

    public GameStates m_GS;
    public GameObject m_Player;
    public GameObject m_Player1Object;
    public GameObject m_Player2Object;
    public Player m_player1;
    public Player m_player2;

    public GameObject m_Spawn;
    public Vector3 m_SpawnLoc;
    public int m_sepXInt;

    public bool m_OneTime;


    void Start()
    {

        m_OneTime = true;
        m_SpawnLoc = m_Spawn.transform.position;



    }

    void Update()
    {
        if ((m_GS.getMenuState() == GameStates.State.GS_NULL) && m_OneTime)
        {
            m_Player1Object = (GameObject)Instantiate(m_Player, new Vector3(m_SpawnLoc.x + m_sepXInt, m_SpawnLoc.y, m_SpawnLoc.z), new Quaternion(0, 0, 0, 0));
            m_player1 = m_Player.GetComponent<Player>();
            m_player1.SetPlayerState(GameStates.State.GS_PLAYER1);

            m_Player2Object = (GameObject)Instantiate(m_Player, new Vector3(m_SpawnLoc.x - m_sepXInt, m_SpawnLoc.y, m_SpawnLoc.z), new Quaternion(0, 0, 0, 0));
            m_player2 = m_Player.GetComponent<Player>();
            m_player2.SetPlayerState(GameStates.State.GS_PLAYER2);
            m_OneTime = false;
        }



        switch (m_GS.getPlayState())
        {
            case GameStates.State.GS_1PLAYER:
                m_Player2Object.SetActive(false);
                break;
            case GameStates.State.GS_2PLAYER:
                m_Player2Object.SetActive(true);
                break;
        }

    }

}
