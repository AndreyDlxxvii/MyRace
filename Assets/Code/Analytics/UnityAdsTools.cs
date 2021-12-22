
using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsTools : MonoBehaviour, IAdsShower
{
    private const string GameId = "4518143";
    private const string VideoId = "Interstitial_Android";
    
    private void Start()
    {
        Advertisement.Initialize(GameId);
    }

    public void ShowInterstitial()
    {
        Advertisement.Show(VideoId);
    }
}
