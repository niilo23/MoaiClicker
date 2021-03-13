using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AdScript : MonoBehaviour
{
    string gameId = "4031997";
    bool TestMode = true; // Test mode saa pysyä päällä myös APK buildissa, sillä en tahdo ottaa riskejä että minut ilmoitetatisiin petoksesta, koska näin voi ilmeisesti käydä jos ei käytä test modea.

    float counter = 0.0f;
    int secBtwAds;

    float rewardCounter;
    int timeTillAvailable = 100;
    public Button rewardButton;
    public Text rewButtonText;
    public Text rewButtonTimeRemaining;
    public GameObject gameManager;

    void Start()
    {
        // Alussa luodaan random numero random mainoksia varten, sekä initialisoidaan mainokset.
        // Poistetaan RewardButtonin käytettävyys, jotta sitä ei voi käyttää ilman että katsoo mainoksen.

        //Debug.Log(secBtwAds);
        secBtwAds = Random.Range(240, 420);
        Advertisement.Initialize(gameId, true);

        rewardButton.interactable = false;
        rewButtonText.color = Color.clear;
    }

    void Update()
    {
        if (counter < secBtwAds)
        {
            // Lisää aikaa counteriin kunnes se on sama kuin secBtwAds
            counter += Time.deltaTime;
        }
        else
        {
            // Näyttää mainoksen ja asettaa counterin takaisin 0 sekä vaihtaa random numeroa.
            Advertisement.Show();

            counter = 0;
            ChangeRN();
        }

        if (rewardCounter < timeTillAvailable)
        {
            // Sama kun ylempi.
            rewardCounter += Time.deltaTime;
        }
        else
        {
            rewardButton.interactable = true;
            rewButtonText.color = Color.white;
        }

        /*if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(secBtwAds);
        }*/

        rewButtonTimeRemaining.text = "Time Remaining: " + (Mathf.Round(timeTillAvailable - rewardCounter)) + "s";

        
    }

    void ChangeRN()
    {
        secBtwAds = Random.Range(240, 420);
    }

    /*public void AdTest()
    {
        Advertisement.Show();
    }*/

    public void AdReward()
    {
        // Lisää sata Moaita sekä näyttää mainoksen
        gameManager.GetComponent<Clickable>().AddMoais(100);
        Advertisement.Show();

        // Poistaa napin toiminnallisuuden, vaihtaa tekstin läpinäkyväksi sekä nollaa counterin
        rewardButton.interactable = false;
        rewButtonText.color = Color.clear;

        rewardCounter = 0;
    }
}
