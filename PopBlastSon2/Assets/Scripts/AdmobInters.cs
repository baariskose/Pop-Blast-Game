using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobInters : MonoBehaviour
{
    public InterstitialAd interstitial;
    // Start is called before the first frame update
    void Start()
    {
        RequestInterstitial();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-6873080491365515/4468559590";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-5087773943034547/3282895079";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);


       
    }
}
