using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AdScript : MonoBehaviour
{
    string gameId = "4031997";
    bool TestMode = true;

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
            counter += Time.deltaTime;
        }
        else
        {
            Advertisement.Show();

            counter = 0;
            ChangeRN();
        }

        if (rewardCounter < timeTillAvailable)
        {
            rewardCounter += Time.deltaTime;
        }
        else
        {
            rewardButton.interactable = true;
            rewButtonText.color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(secBtwAds);
        }

        rewButtonTimeRemaining.text = "Time Remaining: " + (Mathf.Round(timeTillAvailable - rewardCounter)) + "s";

        
    }

    void ChangeRN()
    {
        secBtwAds = Random.Range(240, 420);
    }

    public void AdTest()
    {
        Advertisement.Show();
    }

    public void AdReward()
    {
        gameManager.GetComponent<Clickable>().AddMoais(100);
        Advertisement.Show();

        rewardButton.interactable = false;
        rewButtonText.color = Color.clear;

        rewardCounter = 0;
    }
}
