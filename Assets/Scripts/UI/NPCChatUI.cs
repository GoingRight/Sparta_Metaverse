using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChatUI : BaseUI
{
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
    }

    protected override UIState GetUIstate()
    {
        return UIState.NPCChat;
    }
}
