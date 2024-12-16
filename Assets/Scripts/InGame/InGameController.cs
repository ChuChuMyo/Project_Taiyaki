using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InGameController : MonoBehaviour
{
    public InGameUIController InGameUIController { get; private set; }
    public Order Order { get; private set; }
    public Tray Tray { get; private set; }

    private void Start()
    {
        InGameUIController = FindFirstObjectByType<InGameUIController>();
        Tray = FindFirstObjectByType<Tray>();
        Order = FindFirstObjectByType<Order>();
    }
    public void OnClickBun()
    {
        Tray.tray.Add(Ingredient.Bun);
    }

    public void OnClickLettuce()
    {
        Tray.tray.Add(Ingredient.Lettuce);
    }

    public void OnClickTomato()
    {
        Tray.tray.Add(Ingredient.Tomato);
    }

    public void OnClickCheese()
    {
        Tray.tray.Add(Ingredient.Cheese);
    }

    public void OnClickPatty()
    {
        Tray.tray.Add(Ingredient.Patty);
    }

}
