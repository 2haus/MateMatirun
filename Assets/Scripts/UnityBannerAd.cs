using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityBannerAd : MonoBehaviour
{
#if UNITY_IOS
    private string gameId = "3937750";
#elif UNITY_ANDROID
    private string gameId = "3937751";
#endif

    public string placementId = "MainMenu";
    public bool testMode = true;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementId);
    }

    public void DestroyBanner()
    {
        Advertisement.Banner.Hide();
    }
}