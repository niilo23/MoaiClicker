using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using Random = UnityEngine.Random;

public class AdScript : MonoBehaviour
{
    string gameId = "4031997";
    bool TestMode = true;

    //int secBtwAds = Random.Range(240, 420); // 4 minutes and 7 minutes in seconds respectively
    float counter = 0.0f;
    int secBtwAds;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(secBtwAds);
        secBtwAds = Random.Range(240, 420);
        Advertisement.Initialize(gameId, true);
    }

    // Update is called once per frame
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

        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(secBtwAds);
        }
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

    }
}
