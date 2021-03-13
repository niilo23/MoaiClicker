using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopItemScript : MonoBehaviour
{
    public int amountOf = 0;
    public float priceOfItem;
    public int genAmount;

    public GameObject Controller;

    public List<int> itemAmount = new List<int>();

    public float priceMultiplier; // Multiplies price of item so player cant buy infinite amount of it.

    public Text itemName;
    [TextArea]
    public string title;

    public float updateTime = 10;
    float counter;

    /*void Start()
    {
        LoadShop();
    }*/

    void Update()
    {
        if (counter < updateTime)
        {
            counter += Time.deltaTime;
        }
        else 
        {
            Controller.GetComponent<Clickable>().AddMoais(genAmount * itemAmount.Count);
            counter = 0;
        }

        itemName.text = ( title + Mathf.Round(priceOfItem) + " moais");
    }

    public void BuyItem()
    {
        float moais = Controller.GetComponent<Clickable>().moaiAmount;

        if (moais >= priceOfItem)
        {
            amountOf++;
            Controller.GetComponent<Clickable>().AddMoais(-priceOfItem);
            itemAmount.Add(1);
            

            priceOfItem = priceOfItem * priceMultiplier;
        }
        else
        {
            Debug.Log("Not enough moais to buy");
            Debug.Log(moais);
        }

    }

    public void SaveShop()
    {
        SaveSystem.SaveShop(this);
    }

    public void LoadShop()
    {
        ShopData data = SaveSystem.LoadShop();

        amountOf = data.amount;
        itemAmount = data.amountOfItems;
    }
}
