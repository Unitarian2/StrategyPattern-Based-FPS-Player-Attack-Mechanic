using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableSpawner : MonoBehaviour
{
    public List<PickupableItemSettings> pickupableItemSettings;
    bool isSpawnActive;
    [SerializeField] private GameObject pickupableParent;

    public int currentSpawnableIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartSpawning()
    {
        isSpawnActive = true;
        SpawnSinglePickupable();
    }

    private void SpawnSinglePickupable()
    {
        if(isSpawnActive) StartCoroutine(PickupableSpawnProcess());
    }

    IEnumerator PickupableSpawnProcess()
    {
        yield return new WaitForSeconds(2);
        

        var flyweight = PickupableFactory.Spawn(pickupableItemSettings[currentSpawnableIndex]);
        flyweight.transform.parent = pickupableParent.transform;
        flyweight.transform.position = pickupableItemSettings[currentSpawnableIndex].spawnPos;
        SpawnSinglePickupable();

        currentSpawnableIndex = (currentSpawnableIndex + 1) % pickupableItemSettings.Count;
    }
}
