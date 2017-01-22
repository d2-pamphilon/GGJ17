using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DropDown : MonoBehaviour
{
    public GameStates m_GS;

    public Dropdown m_dropdown;
    public Text m_text;

    public List<string> m_names;

    public int m_int;


    // public string[] ports;

    // Use this for initialization
    void Start()
    {
        PopulateList();
        
    }

    // Update is called once per frame
    void Update()
    {
       switch (m_int)
        {
            case 0: m_GS.SetGameState(GameStates.State.GS_PLAYER, GameStates.State.GS_1PLAYER);
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
        m_text.text = m_names[_index];
    }
}
