using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : BaseUI
{
    //�Ͻ����� ������ư ó�� �Լ�
    public void OnClickResume()
    {
        CloseUI();
        InGameManager.Instance.GameResume();
    }
    //Ȩ ��ư ó�� �Լ�
    public void OnClickHome()
    {
        CloseUI();
        InGameManager.Instance.GameEnd();
    }
}
