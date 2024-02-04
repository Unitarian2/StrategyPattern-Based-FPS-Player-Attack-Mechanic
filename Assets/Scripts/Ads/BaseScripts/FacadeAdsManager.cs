using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacadeAdsManager : Singleton<FacadeAdsManager>
{
    IAdPlugin plugin1;
    IAdPlugin plugin2;
    IAdPlugin plugin3;

    IAdPlugin currentActivePlugin = null;

    List<IAdPlugin> plugins = new();

    // Start is called before the first frame update
    void Start()
    {
        InitPlugin1();
        InitPlugin2();
        InitPlugin3();
        
    }

    private void InitPlugin3()
    {
        var go = new GameObject("AdPlugin3");
        IAdPlugin plugin3 = go.AddComponent<AdPlugin3>();
        go.hideFlags = HideFlags.HideInHierarchy;
        plugins.Add(plugin3);
    }

    private void InitPlugin2()
    {
        var go = new GameObject("AdPlugin2");
        IAdPlugin plugin2 = go.AddComponent<AdPlugin2>();
        go.hideFlags = HideFlags.HideInHierarchy;
        plugins.Add(plugin2);
    }

    private void InitPlugin1()
    {
        var go = new GameObject("AdPlugin1");
        IAdPlugin plugin1 = go.AddComponent<AdPlugin1>();
        go.hideFlags = HideFlags.HideInHierarchy;
        plugins.Add(plugin1);
    }

    public void ShowAds()
    {
        currentActivePlugin?.HideAd();
        currentActivePlugin = GetBestCPM();
        currentActivePlugin.ShowAd();   
    }
    public void HideAds()
    {
        currentActivePlugin?.HideAd();
    }

    private IAdPlugin GetBestCPM()
    {
        IAdPlugin bestCPM = null;
        foreach (var plugin in plugins)
        {
            if (plugin.IsInitialized())//Baþarýlý bir þekilde init olmamýþ plugin'i direkt olarak geçiyoruz.
            {
                if (bestCPM == null)//Ýlk elemanýn atamasýný yapýyoruz.
                {
                    bestCPM = plugin;
                }
                else
                {
                    if (plugin.GetCPM() > bestCPM.GetCPM())//CPM daha iyiyse bestCPM olarak seçiyoruz.
                    {
                        bestCPM = plugin;
                    }
                }
            }
        }

        return bestCPM;
    }
    
}
