using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameStates m_GS;
    public GameObject m_MainMenu;
    public GameObject m_SubMenu;

    public int m_int;
    public int m_Dint;

    public Button m_1playerButton;
    public Button m_2playerButton;
    public Button m_EasyButton;
    public Button m_HardButton;

    public Dropdown m_DropdownMenu;
    public Button m_QuitButton;

    public bool m_show;


    // Use this for initialization
    void Start()
    {
        m_1playerButton.interactable = true;
        m_2playerButton.interactable = true;
        m_EasyButton.interactable = false;
        m_HardButton.interactable = false;

        m_DropdownMenu.interactable = false;
        m_QuitButton.interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
        switch (m_GS.getMenuState())
        {
            case GameStates.State.GS_MAINMENU:
                m_MainMenu.SetActive(true);
                m_SubMenu.SetActive(false);
                break;
            case GameStates.State.GS_SUBMENU:
                m_SubMenu.SetActive(true);
                m_MainMenu.SetActive(false);
                break;
            default:
                m_MainMenu.SetActive(false);
                m_SubMenu.SetActive(false);
                m_DropdownMenu.interactable = true;
                m_QuitButton.interactable = true;
                break;
        }
        if (m_GS.getMenuState() != GameStates.State.GS_NULL)
        {
            
            switch (m_int)
            {
                case 0:
                    m_GS.SetGameState(GameStates.State.GS_PLAYER, GameStates.State.GS_1PLAYER);

                    break;
                case 1:
                    m_GS.SetGameState(GameStates.State.GS_PLAYER, GameStates.State.GS_2PLAYER);
                    break;
            }

            switch (m_Dint)
            {
                case 0:
                    m_GS.SetGameState(GameStates.State.GS_DIFICULTY, GameStates.State.GS_EASYMODE);
                    break;
                case 1:
                    m_GS.SetGameState(GameStates.State.GS_DIFICULTY, GameStates.State.GS_HARDMODE);
                    break;
            }
        }

    }

    public void MenuToSub(GameStates.State _GS)
    {
        m_GS.SetGameState(GameStates.State.GS_CORE, _GS);
    }

    public void Button_Play()
    {
        m_GS.SetGameState(GameStates.State.GS_MENU, GameStates.State.GS_NULL);
    }

    public void Button_Options()
    {
        m_GS.SetGameState(GameStates.State.GS_MENU, GameStates.State.GS_SUBMENU);
    }


    public void Button_Exit()
    {
        print("Quit");
        Application.Quit();
    }

    public void Button_1Player()
    {
        m_int = 0;
        m_1playerButton.interactable = false;
        m_2playerButton.interactable = true;
        m_EasyButton.interactable = false;
        m_HardButton.interactable = false;
    }

    public void Button_2Player()
    {
        m_int = 1;
        m_1playerButton.interactable = true;
        m_2playerButton.interactable = false;
        m_EasyButton.interactable = true;
        m_HardButton.interactable = true;
    }

    public void Button_Back()
    {
        m_GS.SetGameState(GameStates.State.GS_MENU, GameStates.State.GS_MAINMENU);
    }

    public void Button_Easy()
    {
        m_Dint = 0;
        m_EasyButton.interactable = false;
        m_HardButton.interactable = true;
    }
    public void Button_Hard()
    {
        m_Dint = 1;
        m_EasyButton.interactable = true;
        m_HardButton.interactable = false;
    }

    /* public void Button_Player_Inc()
     {
         m_stateInt++;
         if (m_stateInt >= m_ListState.Count)
         {
             m_stateInt = 0;
         }
         m_GS.SetGameState(GameStates.State.GS_PLAYER, m_ListState[m_stateInt]);

        //int t_stateInt = m_stateInt + 1;
        // m_HowManyPlayerText.text = t_stateInt.ToString();


     }
     public void Button_Player_Dec()
     {
         print(m_stateInt);
         m_stateInt--;
         print(m_stateInt);
         if (m_stateInt <= 0)
         {
             m_stateInt = m_ListState.Count;
             print("list size:"); print(m_ListState.Count);
             print("set new:"); print(m_stateInt);
         }
         m_stateInt -= 1;
         m_GS.SetGameState(GameStates.State.GS_PLAYER, m_ListState[m_stateInt]);
         print(m_stateInt);
         print("...");

         //int t_stateInt = m_stateInt + 1;
        // m_HowManyPlayerText.text = m_stateInt.ToString();
     }*/

}
