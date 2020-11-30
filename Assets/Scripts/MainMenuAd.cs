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

        List<string> deviceIds = new List<string>
        {
            "9C49BF91A8843A303BC5E65EF2FCE985",
            "5A436D87B8422ACF30CF5BCD1CBC704A"
        };
        RequestConfiguration requestConfiguration = new RequestConfiguration.Builder().SetTestDeviceIds(deviceIds).build();

        MobileAds.SetRequestConfiguration(requestConfiguration);
    }

    void Update()
    {
        
    }

    void RequestBanner()
    {
        string adUnitId;

        // fill ad unit id
        #if UNITY_ANDROID
            adUnitId = "ca-app-pub-7211801647759739/3939405548";
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
