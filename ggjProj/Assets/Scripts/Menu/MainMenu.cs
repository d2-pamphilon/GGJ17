using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameStates m_GS;
    public GameObject m_MainMenu;
    public GameObject m_SubMenu;
    public bool m_active;

    // Use this for initialization
    void Start()
    {
        m_active = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch(m_GS.getMenuState())
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
                break;
        }
    }

   public void MenuToSub(GameStates.State _GS)
    {
        m_GS.SetGameState(GameStates.State.GS_CORE, _GS);
    }
}
