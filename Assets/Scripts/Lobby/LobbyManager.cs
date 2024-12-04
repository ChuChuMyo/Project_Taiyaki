using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : Singleton<LobbyManager>
{ 
    protected override void Init()
    {
        m_IsDestroyOnLoad = true;
        base.Init();
    }
}
