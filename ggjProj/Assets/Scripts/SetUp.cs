using UnityEngine;
using System.Collections;

public class SetUp : MonoBehaviour
{

    public GameStates m_GS;
    public GameObject m_Player;
    public Player m_player1;
    public Player m_player2;
    // Use this for initialization
    void Start()
    {
        print(m_GS.getPlayState());
        switch (m_GS.getPlayState())
        {
            
            case GameStates.State.GS_1PLAYER: Instantiate(m_Player, new Vector2(1, 0), new Quaternion(0, 0, 0, 0));
                m_player1 = m_Player.GetComponent<Player>();
                m_player1.SetPlayerState(GameStates.State.GS_PLAYER1);
                print("set up p1");
                break;
            case GameStates.State.GS_2PLAYER:
                break;
        }
    }

    // Update is called once per frame
}
