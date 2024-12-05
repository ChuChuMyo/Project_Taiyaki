using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public Transform UICanvasTrs;
    public Transform m_ClosedUITrs;
    //public Transform ClosedUITrs;

    protected override void Init()
    {
        base.Init();
    }
}
