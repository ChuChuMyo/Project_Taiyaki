using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.UI;
using System;

public class UIManager : Singleton<UIManager>
{
    public Transform UICanvasTrs;
    public Transform m_ClosedUITrs;
    //public Transform ClosedUITrs;
    BaseUI m_FrontUI;
    //���� �����ִ�, �� Ȱ��ȭ �Ǿ��ִ� UI ȭ���� ��� �ִ� ����(Ǯ)
    Dictionary<System.Type, GameObject> m_OpenUIPool = new Dictionary<System.Type, GameObject>();
    //�����ִ�, �� ��Ȱ��ȭ �Ǿ� �ִ� UI ȭ���� ��� �ִ� ����(Ǯ)
    Dictionary<System.Type, GameObject> m_ClosedUIPool = new Dictionary<System.Type, GameObject>();

    protected override void Init()
    {
        base.Init();
    }

    //���⸦ ���ϴ� UI ȭ���� ���� �ν��Ͻ��� �������� �Լ�
    //out �Լ����� �Ѱ��� ���̳� ������ ��ȯ�� �� �ֱ� ������
    //�������� ���̳� ������ ��ȯ�ϰ� ���� �� �̷��� out �ŰԺ����� ���
    //�� �Լ��� BaseUI, isAlreadyOpen �ΰ��� ���� ��ȯ
    //�Ŵ����� �ִ� UI�� �������� �����ð� ������ �������� �����ִ� ui�� ��ȯ���ִ� �Լ�
    BaseUI GetUI<T>(out bool isAlreadyOpen)
    {
        //���⼭ T�� ���� ������ �ϴ� ȭ�� UI Ŭ���� Ÿ��. �̰��� uiType���� �޾ƿ´�.
        System.Type uiType = typeof(T);

        BaseUI ui = null;
        isAlreadyOpen = false;

        if (m_OpenUIPool.ContainsKey(uiType))
        {
            //Ǯ�� �ִ� �ش� ������Ʈ�� BaseUI ������Ʈ�� ui������ ����
            ui = m_OpenUIPool[uiType].GetComponent<BaseUI>();
            isAlreadyOpen = true;
        }
        //�׷��� �ʰ� m_ClosedUIPool�� �����Ѵٸ�
        else if (m_ClosedUIPool.ContainsKey(uiType))
        {
            //�ش� Ǯ�� �ִ� BaseUI ������Ʈ�� ui������ ����
            ui = m_ClosedUIPool[uiType].GetComponent<BaseUI>();
            m_ClosedUIPool.Remove(uiType);
        }
        //�Ѵ� �ƴϰ� �ƿ� �ѹ��� ������ ���� ���� �ν��Ͻ����
        else
        {
            //������ ������
            var uiObj = Instantiate(Resources.Load($"UI/{uiType}", typeof(GameObject))) as GameObject;
            //�������� �̸��� �ݵ�� UI Ŭ������ �̸��� �����ؾ���
            //�ֳ��ϸ� UIŬ������ �̸����� ��θ� ���� ���ҽ� �������� �ε��ؿ���� ��û�Ѱű� ������
            ui = uiObj.GetComponent<BaseUI>();
        }
        return ui;
    }

    //Ư�� UIȭ���� �����ִ��� Ȯ���ϰ� �� �����ִ� UIȭ���� �������� �Լ�
    public BaseUI GetActiveUI<T>()
    {
        var uiType = typeof(T);
        //m_OpenUIPool�� Ư�� ȭ�� �ν��Ͻ��� �����Ѵٸ� �� ȭ�� �ν��Ͻ��� ������ �ְ� �׷��� ������ �� ����
        return m_OpenUIPool.ContainsKey(uiType) ? m_OpenUIPool[uiType].GetComponent<BaseUI>() : null;
    }

    //���� UI�� �����԰ų� ���������� UI�� ���½����ִ� �Լ�
    public void OpenUI<T>(BaseUIData uiData)
    {
        System.Type uiType = typeof(T);
        //�̹� �����ִ��� �� �� �ִ� ����
        bool isAlreadyOpen = false;
        var ui = GetUI<T>(out isAlreadyOpen);
        //�ٵ� ���� ui�� ������ �����α� ����ְ� ���� ��Ŵ
        if (!ui)
        {
            return;
        }

        //�����߿� �̹� �����ִٸ� �̰� ���� ���������� ��û�̶�� �Ǵ�
        if (isAlreadyOpen)
        {
            return;
        }

        //���� ��ȿ�� �˻縦 ����ؼ� ���������� UIȭ���� ���� �� �ִٸ�
        //���� ������ UIȭ���� ���� �����͸� ������ �ش�.

        //childCount ������ �ִ� ���� ������Ʈ ����
        var siblingIdx = UICanvasTrs.childCount - 2;

        //UIȭ�� �ʱ�ȭ
        ui.Init(UICanvasTrs);

        //���̶�Ű ���� ���� SetsiblingIndex : �Ű������� �־ ������ ����
        //siblingIdx�� 0���� �����ϴµ� 0, 1, 2, 3 ...
        //�̷��� ������ 1������ �þ��.
        //�����ϰ��� �ϴ� UIȭ���� �̹� �����Ǿ��ִ� UIȭ��� ����
        //��ܿ� ��ġ���� ����ϱ� ������
        //���� �����ϴ� UICanvasTrs ���� ������Ʈ���� ������ �޾ƿͼ�
        //siblingIdx ������ �Ѱ��ִ� ����.
        //siblingIdx�� 0���� �����ϱ� ������ childCount�� ���ο� UIȭ���� �߰��� ��
        //���� ū sublingIdx���� �Ǳ� ����
        //���� ��� �ڽ��� 2�� -> 0, ������ �����Ǹ� 3���� �Ǵµ� �װ� 1�̵ǰ� �״����� �����Ǹ� 2�� �Ǵ� ������
        //�Ź� ĵ�ٽ� �󿡼� ���� �Ʒ��� ��ġ�ϰ� �ǰ� ȭ�鿡���� ���� �ֻ�ܿ� ����
        ui.transform.SetSiblingIndex(siblingIdx);

        //������Ʈ�� ������ ���ӿ�����Ʈ Ȱ��ȭ
        ui.gameObject.SetActive(true);

        //UI ȭ�鿡 ���̴� UI����� �����͸� ��������
        ui.SetInfo(uiData);
        ui.ShowUI();

        //���� �������ϴ� ȭ�� UI�� ���� ��ܿ� �ִ� UI�� �ɰ��̱� ������ �̷��� ����
        m_FrontUI = ui;

        //m_OpenUIPool�� ������ UI�ν��Ͻ��� �־��ش�.
        m_OpenUIPool[uiType] = ui.gameObject;
    }

    //ȭ���� �ݴ� �Լ�
    public void CloseUI(BaseUI ui)
    {
        System.Type uiType = ui.GetType();

        ui.gameObject.SetActive(false);

        //������Ʈ Ǯ���� ����
        m_OpenUIPool.Remove(uiType);

        //Ŭ���� Ǯ���� �߰�
        m_ClosedUIPool[uiType] = ui.gameObject;

        //ClosedUITrs������ ��ġ
        ui.transform.SetParent(m_ClosedUITrs);

        //�ֻ�� UI�η� �ʱ�ȭ
        m_FrontUI = null;

        //���� �ֻ�ܿ� �ִ� UIȭ�� ������Ʈ�� �����´�.
        var lastChild = UICanvasTrs.GetChild(UICanvasTrs.childCount - 1);

        //���� UI�� �����Ѵٸ� �� UIȭ�� �ν��Ͻ��� �ֻ�� UI�� ����
        if (lastChild)
        {
            m_FrontUI = lastChild.gameObject.GetComponent<BaseUI>();
        }
    }


    //UIȭ���� �������� �ϳ��� �ִ��� Ȯ���ϴ� �Լ�
    public bool ExistsOpenUI()
    {
        //m_FrontUI�� null���� �ƴ��� Ȯ���ؼ� �� �Ұ��� ��ȯ
        return m_FrontUI != null;
    }

    public BaseUI GetCurrentFrontUI()
    {
        return m_FrontUI;
    }

    //���� �ֻ�ܿ� �ִ� UIȭ�� �ν��Ͻ��� �ݴ� �Լ�
    public void CloseCurrentFrontUI()
    {
        m_FrontUI.CloseUI();
    }

    //��������� �����ִ� ��� UIȭ���� ������� �Լ�
    public void CloseAllOpenUI()
    {
        while (m_FrontUI)
        {
            m_FrontUI.CloseUI(true);
        }
    }

}
