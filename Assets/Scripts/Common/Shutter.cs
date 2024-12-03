using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shutter : MonoBehaviour
{
    public void ShutterUP()
    {
        transform.DOLocalMoveY(1920, 1).SetEase(Ease.OutQuad);
    }

    public void ShutterDown()
    {
        transform.DOLocalMoveY(0, 1).SetEase(Ease.OutQuad);
    }
}
