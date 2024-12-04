using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : Singleton<UserDataManager>
{
    public UserData userData;

    protected override void Init()
    {
        if (userData == null)
        {
            userData = new UserData();
        }
        LoadUserData();
        base.Init();
    }

    public void SaveUserData(UserData data)
    {
        ES3.Save("UserData", data);
    }

    public void LoadUserData()
    {
        if (ES3.KeyExists("UserData"))
        {
            userData = ES3.Load<UserData>("UserData");
        }
        else
        {
            return;
        }
    }
}
