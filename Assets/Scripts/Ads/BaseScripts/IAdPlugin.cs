using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAdPlugin
{
    public bool IsInitialized();
    public float GetCPM();
    public void ShowAd();
    public void HideAd();
}
