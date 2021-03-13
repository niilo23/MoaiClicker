using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Jos tekisin pelin uusiksi, tekisin ehkä jokaisen rakennuksen omana skriptinään tai jollain muulla loogisemmalla tavalla.

public class ShopItemScript : MonoBehaviour
{
    public int amountOf = 0;
    public float priceOfItem;
    public int genAmount;

    public GameObject Controller;

    public List<int> itemAmount = new List<int>();

    public float priceMultiplier; // Kertoo hinnan jotta pelaaja ei voi loputtomiin ostaa

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
        // Toimii samalla tavalla kun kaikki muut counterit
        if (counter < updateTime)
        {
            counter += Time.deltaTime;
        }
        else 
        {
            // Ottaa rakennuksen genAmount ja kertoo sen listassa olevien rakennusten määrällä.
            Controller.GetComponent<Clickable>().AddMoais(genAmount * itemAmount.Count);
            counter = 0;
        }

        // Käytän Mathf.Round koska en tykkää siitä kuinka floateissa näkyy niin monta desimaalia
        itemName.text = ( title + Mathf.Round(priceOfItem) + " moais");
    }

    public void BuyItem()
    {
        // Ottaa moai määrän toisesta skriptistä
        float moais = Controller.GetComponent<Clickable>().moaiAmount;

        if (moais >= priceOfItem)
        {
            // Lisää yhden esineen listaan, poistaa moaita priceOfItem muuttujan mukaan
            // En muuten tiedä miksi tein tähän kaksi tälläistä, amountOf ja list itemAmount, kumpikin olisi toiminut siinä kohdassa jossa lisätään moaita >_<
            amountOf++;
            Controller.GetComponent<Clickable>().AddMoais(-priceOfItem);
            itemAmount.Add(1);
            
            // Kertoo tuotteen hinnan kertoimella
            priceOfItem = priceOfItem * priceMultiplier;
        }
        else // Omaa testausta varten
        {
            Debug.Log("Not enough moais to buy");
            Debug.Log(moais);
        }

    }
}
