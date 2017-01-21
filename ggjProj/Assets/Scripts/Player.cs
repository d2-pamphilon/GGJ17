using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public GameStates m_GS;
    public GameObject m_player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (m_GS.getCoreState())
        {

            case GameStates.State.GS_P_START: //initilise player/s
                break;
            case GameStates.State.GS_P_PLAY: // actual game
                break;
            case GameStates.State.GS_P_DEATH: //rip
                break;
            default:
                m_player.SetActive(false); //purley for pause menu (stretch goal)
                break;
        }
    }
}