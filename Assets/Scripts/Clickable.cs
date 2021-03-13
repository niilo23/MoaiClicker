using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class Clickable : MonoBehaviour
{
    public float moaiAmount = 0; // Moait on pelin rahayksikkö, älä kysy.
    public int moaisPerSecond;

    public Text amountText;
    public Text perSecondText;

    public float updateTime;
    float counter;

    void Update()
    {
        amountText.text = (Mathf.Round(moaiAmount) + " Moais");

        perSecondText.text = (Mathf.Round(counter) + " Per Second");

        // Tutoriaali jonka mukaan koitin tehdä Per Second counterin ei oikein selvästi ollut kunnollinen, joten jätän sen nyt väliin, ei se ole oleellinen
        if (counter<updateTime)
        {
            counter += Time.deltaTime;
        }
        else
        {
            moaiAmount += moaisPerSecond * (int)updateTime;

            counter = 0;
        }

        // Tarkistaa että moait ei koskaan mene negatiiviselle 
        if (moaiAmount < 0)
        {
            moaiAmount = 0;
        }
    }

    public void AddMoais(float i)
    {
        // Lisää moaita float i:n mukaan
        moaiAmount = moaiAmount + i;

        // En tiedä mitä tämä tekee tbh
        Analytics.CustomEvent("Times Clicker Clicked");
    }
}
