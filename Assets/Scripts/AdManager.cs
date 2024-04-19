using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdManager : MonoBehaviour
{
    private const string APP_KEY = "";

    [SerializeField] private bool testingMode;

    
    void Start()
    {
        Initialized();
    }

    public void ShowInterAds()
    {
        if (Appodeal.IsLoaded(AppodealAdType.Interstitial))
        {
            Appodeal.Show(AppodealShowStyle.Interstitial);
        }
    }

    private void Initialized()
    {
        Appodeal.SetTesting(testingMode);

        Appodeal.MuteVideosIfCallsMuted(true);

        Appodeal.Initialize(APP_KEY, AppodealAdType.Interstitial);

        AppodealCallbacks.Interstitial.OnClosed += OnInterstitialClosed;
        AppodealCallbacks.Interstitial.OnShown += OnInterstitialShown;
    }

    #region InterstitialAd Callbacks

    private void OnInterstitialLoaded(object sender, AdLoadedEventArgs e)
    {
        Debug.Log("Interstitial loaded");
    }

    private void OnInterstitialFailedToLoad(object sender, EventArgs e)
    {
        Debug.Log("Interstitial failed to load");
    }

    private void OnInterstitialShowFailed(object sender, EventArgs e)
    {
        Debug.Log("Interstitial show failed");
    }

    private void OnInterstitialShown(object sender, EventArgs e)
    {
        Debug.Log("Interstitial shown");
    }

    public void OnInterstitialClosed(object sender, EventArgs e)
    {
        Debug.Log("Interstitial closed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnInterstitialClicked(object sender, EventArgs e)
    {
        Debug.Log("Interstitial clicked");
    }

    private void OnInterstitialExpired(object sender, EventArgs e)
    {
        Debug.Log("Interstitial expired");
    }

    #endregion 
}
