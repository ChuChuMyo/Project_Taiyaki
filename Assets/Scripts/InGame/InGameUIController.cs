using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InGameUIController : MonoBehaviour
{
    [SerializeField]
    private SceneNames nextScene;
    [SerializeField]
    private Slider timerSlider;
    [SerializeField]
    private TextMeshProUGUI incomeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerSlider.value = InGameManager.Instance.gameTimer / 60f;
    }

    public void OnClickExit()
    {
        InGameManager.Instance.GameEnd();
    }

    public void OnClickPauseBtn()
    {
        var uiData = new BaseUIData();
        InGameManager.Instance.GamePause();
        UIManager.Instance.OpenUI<PauseUI>(uiData);
    }

}
