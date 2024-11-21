using UnityEngine;

//Singleton Design Pattern
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    //�� ��ȯ �� �������� ����
    protected bool m_IsDestroyOnLoad = false;
    //�� Ŭ������ ����ƽ �ν��Ͻ� ����
    protected static T m_Instance;

    public static T Instance
    { get { return m_Instance; } }

    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        if (m_Instance == null)
        {
            m_Instance = (T)this;

            if (!m_IsDestroyOnLoad)
            {
                DontDestroyOnLoad(this);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //���� �� ���� �Ǵ� �Լ�
    protected virtual void OnDestroy()
    {
        Dispose();
    }

    //���� �� �߰��� ó���� �־���� �۾��� �Լ��� ����� ó��
    protected virtual void Dispose()
    {
        m_Instance = null;
    }
}