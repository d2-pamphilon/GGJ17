using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public GameStates m_GS;
    public GameStates.State m_PlayerState;
    public GameObject m_player;

    // Use this for initialization
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
       
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