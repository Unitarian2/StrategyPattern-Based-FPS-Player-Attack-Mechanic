using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject circlePrefab;
    MagicCircleFactory magicCircleFactory;
    
    void Start()
    {
        
        
    }

    public void CircleSpawnManagerSetup()
    {
        magicCircleFactory = GetComponent<MagicCircleFactory>();
        StartCoroutine(StartCircleSpawnProcess());
    }

    private IEnumerator StartCircleSpawnProcess()
    {
        yield return new WaitForSeconds(10f);
        SpawnSingleMagicCircle(GetRandomSpawnPos());
    }

    void SpawnSingleMagicCircle(Vector3 spawnPos)
    {
        ICircle spawnedCircle = magicCircleFactory.GetMagicCircle(spawnPos);
        spawnedCircle.GetGameObject().transform.parent.gameObject.SetActive(true);
        spawnedCircle.StartLifeCycle();
        StartCoroutine(StartCircleSpawnProcess());
    }

    Vector3 GetRandomSpawnPos()
    {
        return new Vector3(UnityEngine.Random.Range(-7f, 7f), 0f, UnityEngine.Random.Range(8.3f,9.3f));
    }
}
