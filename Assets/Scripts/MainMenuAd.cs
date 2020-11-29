using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class MainMenuAd : MonoBehaviour
{
    private BannerView view;

    void Start()
    {
        // init
        MobileAds.Initialize(initStatus => { });
        RequestBanner();
    }

    void Update()
    {
        
    }

    void RequestBanner()
    {
        string adUnitId;

        // fill ad unit id
        #if UNITY_ANDROID
            adUnitId = "ca-app-pub-3940256099942544/6300978111"; // sample ad unit from google
        #else
            adUnitId = "unexpected_platform";
        #endif

        view = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        view.LoadAd(request);
    }

    public void DestroyBanner()
    {
        view.Destroy();
    }
}
