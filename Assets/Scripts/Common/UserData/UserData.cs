using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{

    //[BoxGroup("Player Data/Basic Data")]
    //public int playerLevel;

    public int playerMoney = 1000;

    [Range(0f, 1f)]
    public float audioVolume;
    //[BoxGroup("Settings/Graphics")]
    //public string graphicsQuality;
}
