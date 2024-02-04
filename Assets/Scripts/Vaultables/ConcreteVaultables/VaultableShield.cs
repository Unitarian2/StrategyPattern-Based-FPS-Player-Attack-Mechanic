using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultableShield : MonoBehaviour, IVaultableWeapon
{
    [SerializeField] private Transform vaultedPoint;
    [SerializeField] private Transform unvaultedPoint;

 

    [SerializeField] private float vaultDistance = 1f;
    private Coroutine currentCoroutine;
    private Vector3 initialLocalPosition;
    private Quaternion initialLocalRotation;


    private void Start()
    {
        // Ba�lang��ta Shield'�n yerel pozisyonunu ve rotasyonunu kaydet
        initialLocalPosition = transform.localPosition;
        initialLocalRotation = transform.localRotation;

    }

    public void Vault(bool doVault)
    {
        //if (doVault)
        //{
        //    if(currentCoroutine != null) StopCoroutine(currentCoroutine);
        //    currentCoroutine = StartCoroutine(MoveTo(vaultedPoint.position, 1f));
        //}
        //else
        //{
        //    if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        //    currentCoroutine = StartCoroutine(MoveTo(unvaultedPoint.position, 1f));
        //}
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        if (doVault)
        {
            // Vault i�lemi ba�lat�l�r
            currentCoroutine = StartCoroutine(VaultAnimation(0.5f));
        }
        else
        {
            // Vault geri alma i�lemi ba�lat�l�r
            currentCoroutine = StartCoroutine(UnvaultAnimation(1f));
        }

    }

    IEnumerator MoveTo(Vector3 reachPos, float duration)
    {
        float timeElapsed = 0f;
        Vector3 initialPos = transform.position;
        Vector3 finalPos = reachPos;

        while (timeElapsed < duration)
        {
            //transform.Translate(Vector3.Lerp(initialPos, finalPos, timeElapsed / duration));
            //transform.position = transform.parent.position + initialOffset + Vector3.Lerp(Vector3.zero, reachPos - initialPos, timeElapsed / duration);
            transform.position = Vector3.Lerp(initialPos, finalPos, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator VaultAnimation(float duration)
    {
        float timeElapsed = 0f;
        Vector3 targetPosition = initialLocalPosition - new Vector3(vaultDistance, 0f, 0f);

        while (timeElapsed < 1f)
        {
            transform.localPosition = Vector3.Lerp(initialLocalPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Vault i�lemi tamamland���nda, Shield'� Vaulted pozisyonunda sabitle
        transform.localPosition = targetPosition;
    }

    IEnumerator UnvaultAnimation(float duration)
    {
        float timeElapsed = 0f;
        Vector3 targetPosition = initialLocalPosition;

        while (timeElapsed < 1f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Vault geri alma i�lemi tamamland���nda, Shield'� orijinal pozisyonunda sabitle
        transform.localPosition = targetPosition;
    }

    public GameObject GetGameobject()
    {
        return gameObject;
    }

    //private void LateUpdate()
    //{
    //    // Shield'� her frame'de Camera'n�n pozisyonu ve rotasyonuna uygun olarak yerle�tir
    //    if (!isVaulted)
    //    {
    //        transform.position = transform.parent.position + initialOffset;
    //        transform.rotation = transform.parent.rotation;
    //    }
    //}
}
