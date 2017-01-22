using UnityEngine;
using System.Collections;

public class SetUp : MonoBehaviour
{

    public GameStates m_GS;
    public GameObject m_Player;
    public Player m_player1;
    public Player m_player2;

    public GameObject m_Spawn;
    public Vector3 m_SpawnLoc;
    public int m_sepXInt;

    public bool m_active;
    // Use this for initialization
    void Start()
    {

        m_SpawnLoc = m_Spawn.transform.position;

        Instantiate(m_Player, new Vector3(m_SpawnLoc.x + m_sepXInt, m_SpawnLoc.y, m_SpawnLoc.z) , new Quaternion(0, 0, 0, 0));
        m_player1 = m_Player.GetComponent<Player>();
        m_player1.SetPlayerState(GameStates.State.GS_PLAYER1);

        Instantiate(m_Player, new Vector3(m_SpawnLoc.x - m_sepXInt, m_SpawnLoc.y, m_SpawnLoc.z) , new Quaternion(0, 0, 0, 0));
        m_player2 = m_Player.GetComponent<Player>();
        m_player2.SetPlayerState(GameStates.State.GS_PLAYER2);


    }

    void Update()
    {
       /*switch(m_GS.getPlayState())
        {
            case GameStates.State.GS_1PLAYER:
                break;
            case GameStates.State.GS_2PLAYER:
               break;
        }*/
    }




    // Update is called once per frame
}
