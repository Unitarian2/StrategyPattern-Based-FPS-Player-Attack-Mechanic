using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AdPlugin2 : MonoBehaviour, IAdPlugin
{
    Plugin2InitResult initResult = Plugin2InitResult.Failed;
    GameObject currentAdObject;

    public AdPlugin2()
    {
        Init();
    }


    private void Init()
    {
        OnInitCallback(Plugin2InitResult.Success);
    }

    private void OnInitCallback(Plugin2InitResult result)
    {
        initResult = result;
    }

    public bool IsInitialized()
    {
        if (initResult == Plugin2InitResult.Success)
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
        Debug.Log("AdPlugin2 Ads Show");
        GameObject adObject = Resources.Load("Ads/Plugin2") as GameObject;
        currentAdObject = Instantiate(adObject);
        currentAdObject.hideFlags = HideFlags.HideInHierarchy;
    }

    public void HideAd()
    {
        Debug.Log("AdPlugin2 Ads Hide");
        Destroy(currentAdObject);
    }
}

public enum Plugin2InitResult
{
    Success,
    Failed
}
