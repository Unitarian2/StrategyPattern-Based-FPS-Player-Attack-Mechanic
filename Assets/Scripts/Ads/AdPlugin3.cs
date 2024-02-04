using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AdPlugin3 : MonoBehaviour, IAdPlugin
{
    Plugin3InitResult initResult = Plugin3InitResult.Failed;
    GameObject currentAdObject;

    public AdPlugin3()
    {
        Initialize();
    }

    private void Initialize()
    {
        OnInitialized(Plugin3InitResult.Success);
    }

    private void OnInitialized(Plugin3InitResult result)
    {
        initResult = result;
    }

    public bool IsInitialized()
    {
        if (initResult == Plugin3InitResult.Success)
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
        Debug.Log("AdPlugin3 Ads Show");
        GameObject adObject = Resources.Load("Ads/Plugin3") as GameObject;
        currentAdObject = Instantiate(adObject);
        currentAdObject.hideFlags = HideFlags.HideInHierarchy;
    }

    public void HideAd()
    {
        Debug.Log("AdPlugin3 Ads Hide");
        Destroy(currentAdObject);
    }
}

public enum Plugin3InitResult
{
    Success,
    Failed
}
