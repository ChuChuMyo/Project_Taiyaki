using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using DG.Tweening;

public class UIManager : Singleton<UIManager>
{
    [Title("Main Menu Settings")]
    [FoldoutGroup("Button Colors")]
    [GUIColor(0.3f, 0.6f, 1f)]
    public Color startButtonColor = Color.blue;

    [FoldoutGroup("Button Colors")]
    [GUIColor(1f, 0.4f, 0.4f)]
    public Color exitButtonColor = Color.red;

    [Title("Audio Settings")]
    [FoldoutGroup("Volume Control")]
    [Range(0f, 1f)]
    public float volumeLevel = 0.5f;

    [FoldoutGroup("Volume Control")]
    public bool muteAudio = false;

    [Button("Reset UI Settings")]
    private void ResetSettings()
    {
        startButtonColor = Color.blue;
        exitButtonColor = Color.red;
        volumeLevel = 0.5f;
        muteAudio = false;
    }
}
