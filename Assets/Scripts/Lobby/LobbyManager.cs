using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : Singleton<LobbyManager>
{
    [SerializeField]
    private SceneNames nextScene;
    protected override void Init()
    {
        m_IsDestroyOnLoad = true;
        base.Init();
    }

    public void OnClickGameStart()
    {
        Utils.LoadScene(nextScene);
    }
}
