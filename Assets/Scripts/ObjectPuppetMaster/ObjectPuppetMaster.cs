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

    public IEnumerator StrafeToLeft(GameObject obj,float strafeAmount,float duration)
    {
        float timeElapsed = 0f;
        Vector3 initialPos = obj.transform.position;
        Vector3 finalPos = new Vector3(initialPos.x + strafeAmount, initialPos.y, initialPos.z);

        while (timeElapsed < duration)
        {
            obj.transform.position = Vector3.Lerp(initialPos, finalPos, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
    public IEnumerator StrafeToRight(GameObject obj, float strafeAmount, float duration)
    {
        float timeElapsed = 0f;
        Vector3 initialPos = obj.transform.position;
        Vector3 finalPos = new Vector3(initialPos.x - strafeAmount, initialPos.y, initialPos.z);

        while (timeElapsed < duration)
        {
            obj.transform.position = Vector3.Lerp(initialPos, finalPos, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
    
}
