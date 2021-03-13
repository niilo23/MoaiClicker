using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopData
{
    public int amount;
    public List<int> amountOfItems = new List<int>();

    public ShopData (ShopItemScript shopItemScript)
    {
        amount = shopItemScript.amountOf;
        amountOfItems = shopItemScript.itemAmount;

    }
}
