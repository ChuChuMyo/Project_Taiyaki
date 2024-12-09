using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : BaseUI
{
    //일시정지 해제버튼 처리 함수
    public void OnClickResume()
    {
        CloseUI();
        InGameManager.Instance.GameResume();
    }
    //홈 버튼 처리 함수
    public void OnClickHome()
    {
        CloseUI();
        InGameManager.Instance.GameEnd();
    }
}
