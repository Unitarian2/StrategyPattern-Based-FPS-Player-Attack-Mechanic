using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AdProcess());
        
    }

    IEnumerator AdProcess()
    {  
        yield return new WaitForSeconds(5);
        FacadeAdsManager.Instance.ShowAds();
        StartCoroutine(AdProcess());
    }


    private void OnDisable()
    {
        
        StopCoroutine(AdProcess());
    }
}
