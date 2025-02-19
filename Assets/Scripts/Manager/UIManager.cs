using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum UIState
{
    NPCChat
}

public class UIManager : MonoBehaviour
{
    NPCChatUI npcChatUI;

    private UIState currentState;

    private void Awake()
    {
        npcChatUI = GetComponentInChildren<NPCChatUI>(true);
        npcChatUI.Init(this);
    }

    public void ChangeState(UIState state)
    {

    }
}
