using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DropDown : MonoBehaviour
{
    public GameStates m_GS;

    public Dropdown m_dropdown;


    public List<string> m_names;

    public int m_int;
    public bool m_once;

    // public string[] ports;

    // Use this for initialization
    void Start()
    {
        m_once = true;
        PopulateList();

    }

    // Update is called once per frame
    void Update()
    {

        if (m_GS.getMenuState() == GameStates.State.GS_NULL)
        {
            if (m_once)
            {
                if (m_GS.getPlayState() == GameStates.State.GS_1PLAYER)
                {
                    m_int = 0;
                }
                else
                {
                    if ((m_GS.getPlayState() == GameStates.State.GS_2PLAYER) && (m_GS.getDificulState() == GameStates.State.GS_EASYMODE))
                    {
                        m_int = 1;
                    }
                    if ((m_GS.getPlayState() == GameStates.State.GS_2PLAYER) && (m_GS.getDificulState() == GameStates.State.GS_HARDMODE))
                    {
                        m_int = 2;
                    }
                }
                m_once = false;
            }
        }

        switch (m_int)
        {
            case 0:
                m_GS.SetGameState(GameStates.State.GS_PLAYER, GameStates.State.GS_1PLAYER);

                break;
            case 1:

                m_GS.SetGameState(GameStates.State.GS_PLAYER, GameStates.State.GS_2PLAYER);
                m_GS.SetGameState(GameStates.State.GS_DIFICULTY, GameStates.State.GS_EASYMODE);
                break;
            case 2:

                m_GS.SetGameState(GameStates.State.GS_PLAYER, GameStates.State.GS_2PLAYER);
                m_GS.SetGameState(GameStates.State.GS_DIFICULTY, GameStates.State.GS_HARDMODE);
                break;
        }




    }

    void PopulateList()
    {
        m_dropdown.AddOptions(m_names);
    }

    public void DropdownIndexChanged(int _index)
    {
        m_int = _index;
    }

    public void GameButton_Quit()
    {
        print("quit");
        Application.Quit();
        
    }
}
