using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    public List<Ingredient> tray = new List<Ingredient>(4);
    public Ingredient ingredient;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddIngredient()
    {
        for (int i = 0; i < tray.Count; i++)
        {
            tray[i] = ingredient;
            switch (ingredient)
            {
                case Ingredient.Bun:
                    break;
                case Ingredient.Cheese:
                    break;
                case Ingredient.Tomato:
                    break;
                case Ingredient.Lettuce:
                    break;
                case Ingredient.Patty:
                    break;
            }
        }
    }
}
