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
    public TextMeshProUGUI incomeText;

    public TextMeshProUGUI orderRecipe;
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

    public void UpdateUI()
    {
        incomeText.text = UserDataManager.Instance.userData.playerMoney + "";
    }

    public void ShowOrder()
    {
        orderRecipe.text = "";
        for (int i = 0; i < InGameManager.Instance.recipe.Count; i++)
        {
            orderRecipe.text += InGameManager.Instance.recipe[i].ToString() + "\n";
        }
    }
}
