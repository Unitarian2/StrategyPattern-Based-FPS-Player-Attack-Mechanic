using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPuppetMaster : Singleton<ObjectPuppetMaster>
{
    public IEnumerator ScaleTo(GameObject obj, Vector3 finalScale, float duration, Action onComplete)
    {
        float timeElapsed = 0f;
        Vector3 initialScale = obj.transform.localScale;

        while (timeElapsed < duration)
        {
            obj.transform.localScale = Vector3.Lerp(initialScale, finalScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        onComplete?.Invoke();
    }
    public IEnumerator ScaleTo(GameObject obj, Vector3 finalScale, float duration)
    {
        float timeElapsed = 0f;
        Vector3 initialScale = obj.transform.localScale;

        while (timeElapsed < duration)
        {
            obj.transform.localScale = Vector3.Lerp(initialScale, finalScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

}
