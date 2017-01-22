using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public GameStates m_GS;
    public GameObject m_GameState;
    public GameStates.State m_PlayerState;
    public GameObject m_player;
    public bool m_active;

    // Use this for initialization
    void Start()
    {
        m_GameState = GameObject.FindGameObjectWithTag("GameStateSystem");
        m_GS = m_GameState.GetComponent<GameStates>();




    }

    // Update is called once per frame
    void Update()
    {
       /* if (m_PlayerState == GameStates.State.GS_PLAYER2)
        {
            if (m_GS.getPlayState() == GameStates.State.GS_1PLAYER)
            {
                m_active = false;
                print("Active False");
            }
            else
            {
                m_active = true;
                print("Active True");
            }
        }
        m_player.SetActive(m_active);*/


    }

    public void SetPlayerState(GameStates.State _GS)
    {
        m_PlayerState = _GS;
    }

    public GameStates.State GetPlayerState()
    {
        return m_PlayerState;
    }
}