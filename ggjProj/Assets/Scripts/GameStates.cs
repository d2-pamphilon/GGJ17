using UnityEngine;
using System.Collections;

public class GameStates : MonoBehaviour
{

    public enum State
    {
        GS_NULL = 0,
        //Menu States
        GS_MAINMENU = 1,
        GS_SUBMENU,
        GS_PAUSE,
        //Core States
        GS_P_START,
        GS_P_PLAY,
        GS_P_DEATH,
        //Player states
        GS_1PLAYER = 10,
        GS_2PLAYER,
        //Define Player state
        GS_PLAYER1,
        GS_PLAYER2,
        //Difficulty states
        GS_EASYMODE = 20,
        GS_HARDMODE,
        //Enemy states
        
        //Main States
        GS_CORE = 100,
        GS_MENU,
        GS_PLAYER,
        GS_MULTIPLAYER,
        GS_DIFICULTY,
        GS_ENEMY

    };

    public State m_GSState;
    public State m_GSMenu;
    public State m_GSCore;
    public State m_GSPlayer;
    public State m_GSMultiPlayer;
    public State m_GSDificulty;


    // Use this for initialization
    void Start()
    {
        m_GSState = State.GS_CORE;
        m_GSMenu = State.GS_MAINMENU;
        m_GSCore = State.GS_NULL;
        m_GSPlayer = State.GS_NULL;
        m_GSMultiPlayer = State.GS_NULL;
        m_GSDificulty = State.GS_NULL;
    }


    public void SetGameState(State _State, State _GS)
    {
        switch (_State)
        {
            case State.GS_CORE:
                m_GSCore = _GS;
                break;
            case State.GS_MENU:
                m_GSMenu = _GS;
                break;
            case State.GS_PLAYER:
                m_GSPlayer = _GS;
                break;
            case State.GS_MULTIPLAYER:
                m_GSMultiPlayer = _GS;
                break;
            case State.GS_DIFICULTY:
                m_GSDificulty = _GS;
                break;

        }

        //m_GSCore = _GS;
    }

    public State getCoreState()
    {
        return m_GSCore;
    }
    public State getMenuState()
    {
        return m_GSMenu;
    }
    public State getPlayState( )
    {
        return m_GSPlayer;
    }
    public State getMultiState( )
    {
        return m_GSMultiPlayer;
    }
    public State getDificulState( )
    {
        return m_GSDificulty;
    }

}
