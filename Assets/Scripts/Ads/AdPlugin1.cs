using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AdPlugin1 : MonoBehaviour, IAdPlugin
{
    Plugin1InitResult initResult = Plugin1InitResult.Failed;
    GameObject currentAdObject;

   public AdPlugin1()
    {
        InitPlugin();
    }

    
    private void InitPlugin()
    {
        OnInitializationCompleted(Plugin1InitResult.Success);
    }

    private void OnInitializationCompleted(Plugin1InitResult result)
    {
        initResult = result;
    }

    public bool IsInitialized()
    {
        if(initResult == Plugin1InitResult.Success)
        {
            return true;
        }
        else return false;
    }

    public float GetCPM()
    {
        return Random.Range(0.0f, 10.0f);
    }

    public void ShowAd()
    {
        Debug.Log("AdPlugin1 Ads Show");
        GameObject adObject = Resources.Load("Ads/Plugin1") as GameObject;
        currentAdObject = Instantiate(adObject);
        currentAdObject.hideFlags = HideFlags.HideInHierarchy;
    }

    public void HideAd()
    {
        Debug.Log("AdPlugin1 Ads Hide");
        Destroy(currentAdObject);
    }
}

public enum Plugin1InitResult{
    Success,
    Failed
}
