using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InGameController : MonoBehaviour
{
    public InGameUIController InGameUIController { get; private set; }

    private void Start()
    {
        InGameUIController = FindFirstObjectByType<InGameUIController>();
    }
    public void OnClickBun()
    {
        InGameManager.Instance.tray.Add(Ingredient.Bun);
    }

    public void OnClickLettuce()
    {
        InGameManager.Instance.tray.Add(Ingredient.Lettuce);
    }

    public void OnClickTomato()
    {
        InGameManager.Instance.tray.Add(Ingredient.Tomato);
    }

    public void OnClickCheese()
    {
        InGameManager.Instance.tray.Add(Ingredient.Cheese);
    }

    public void OnClickPatty()
    {
        InGameManager.Instance.tray.Add(Ingredient.Patty);
    }

    public void OnClickSale()
    {
        if (InGameManager.Instance.recipe.SequenceEqual(InGameManager.Instance.tray))
        {
            UserDataManager.Instance.userData.playerMoney += 100;
            InGameUIController.UpdateUI();
            InGameManager.Instance.recipe.Clear();
            InGameManager.Instance.tray.Clear();
            InGameUIController.ShowOrder();
            return;
        }
        else
        {
            InGameManager.Instance.recipe.Clear();
            InGameManager.Instance.tray.Clear();
            return;
        }
    }
}
