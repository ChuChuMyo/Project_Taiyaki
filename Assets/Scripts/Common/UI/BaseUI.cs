using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BaseUIData
{
    //UIȭ���� ������ �� ���ְ� ���� ������ ����
    public Action OnShow;
    //UIȭ���� �����鼭 �����ؾ� �Ǵ� ��� ����
    public Action OnClose;
}
public class BaseUI : MonoBehaviour
{
    public Action m_OnShow;
    public Action m_OnClose;

    public virtual void Init(Transform anchor)
    {
        m_OnShow = null;
        m_OnClose = null;
        transform.SetParent(anchor);
        
        var rectTransform = GetComponent<RectTransform>();
        if (!rectTransform)
        {
            return;
        }

        rectTransform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.localScale = new Vector3(1f, 1f, 1f);
        rectTransform.offsetMin = new Vector2(0, 0);
        rectTransform.offsetMax = new Vector2(0, 0);
        
    }


    public virtual void SetInfo(BaseUIData uiData)
    {
        m_OnShow = uiData.OnShow;
        m_OnClose = uiData.OnClose;
    }

    //UI ȭ���� ������ ��� ȭ�鿡 ǥ���� �ִ� �Լ�
    public virtual void ShowUI()
    {
        m_OnShow?.Invoke();//�ΰ˻�� ������
        //? Ű���带 ����� ���� ó��
        //_action?.Invoke(3); //if(action != null)�� ?Ű���带 ����Ͽ� null���� üũ

        m_OnShow = null;//���� �Ŀ��� �η� �ʱ�ȭ
    }

    //UIȭ���� �ݴ� �Լ�
    public virtual void CloseUI(bool isCloseAll = false)
    {
        if (!isCloseAll)
        {
            m_OnClose?.Invoke();
        }
        m_OnClose = null;

        UIManager.Instance.CloseUI(this);
    }

    public virtual void OnClickCloseButton()
    {
        CloseUI();
    }

}
