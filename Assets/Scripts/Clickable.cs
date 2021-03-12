using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class Clickable : MonoBehaviour
{
    public float moaiAmount = 0;
    public int moaisPerSecond;

    public Text amountText;
    public Text perSecondText;

    public float updateTime;
    float counter;

    void Update()
    {
        amountText.text = (Mathf.Round(moaiAmount) + " Moais");

        perSecondText.text = (Mathf.Round(counter) + " Per Second");

        if (counter<updateTime)
        {
            counter += Time.deltaTime;
        }
        else
        {
            moaiAmount += moaisPerSecond * (int)updateTime;

            counter = 0;
        }

        if (moaiAmount < 0)
        {
            moaiAmount = 0;
        }
    }

    public void AddMoais(float i)
    {
        moaiAmount = moaiAmount + i;

        Analytics.CustomEvent("Times Clicker Clicked");
    }
}
