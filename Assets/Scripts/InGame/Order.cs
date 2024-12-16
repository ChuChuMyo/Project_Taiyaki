using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class Order : MonoBehaviour
{
    public InGameUIController InGameUIController { get; private set; }
    public Tray Tray { get; private set; }

    public Slider orderTimer;
    public float time;

    public TextMeshProUGUI orderNumber;
    public TextMeshProUGUI orderRecipe;
    public List<Ingredient> recipe = new List<Ingredient>(4);
    public Queue<List<Ingredient>> orderQueue = new Queue<List<Ingredient>>(3);
    private void Start()
    {
        InGameUIController = FindFirstObjectByType<InGameUIController>();
        Tray = FindFirstObjectByType<Tray>();
        time = 10;
        AddOrder();
        ShowOrder();
    }

    // Update is called once per frame
    void Update()
    {
        if(orderRecipe.text != "" && InGameManager.Instance.gameState == GameState.Playing)
        {
            time -= Time.deltaTime;
            orderTimer.value = time / 10;
        }
        if(time<=0)
        {
            recipe.Clear();
        }
    }

    public void AddOrder()
    {
        InGameManager.Instance.orderNum++;
        recipe.Add(Ingredient.Bun);
        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            recipe.Add((Ingredient)Random.Range(1, 5));
        }
        recipe.Add(Ingredient.Bun);
        //Order.ShowOrder();
        orderQueue.Enqueue(recipe);
    }

    public void ShowOrder()
    {
        orderNumber.text = "Order No." + InGameManager.Instance.orderNum;
        orderRecipe.text = "";
        for (int i = 0; i < recipe.Count; i++)
        {
            orderRecipe.text += recipe[i].ToString() + "\n";
        }
    }

    public void ClearOrder()
    {
        orderNumber.text = "";
        orderRecipe.text = "";
    }

    public void OnClickOrder()
    {
        if (recipe.SequenceEqual(Tray.tray))
        {
            UserDataManager.Instance.userData.playerMoney += 100;
            InGameUIController.UpdateUI();
            recipe.Clear();
            Tray.tray.Clear();
            ClearOrder();
            return;
        }
        else
        {
            Tray.tray.Clear();
            return;
        }
    }
}
