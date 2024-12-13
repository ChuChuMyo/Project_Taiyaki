using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public Slider orderTimer;
    public float time;

    public TextMeshProUGUI orderNumber;
    public TextMeshProUGUI orderRecipe;

    // Start is called before the first frame update
    void Start()
    {
        time = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(InGameManager.Instance.gameState == GameState.Playing)
        {
            time -= Time.deltaTime;
            orderTimer.value = time / 10;
        }
    }

    public void ShowOrder()
    {
        orderNumber.text = "Order No." + InGameManager.Instance.orderNum;
        orderRecipe.text = "";
        for (int i = 0; i < InGameManager.Instance.recipe.Count; i++)
        {
            orderRecipe.text += InGameManager.Instance.recipe[i].ToString() + "\n";
        }
    }
}
