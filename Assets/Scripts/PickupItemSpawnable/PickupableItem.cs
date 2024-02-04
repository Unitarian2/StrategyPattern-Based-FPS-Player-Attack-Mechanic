using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : Flyweight, IAutoPickupable
{
    new PickupableItemSettings settings => (PickupableItemSettings) base.settings;

    private void OnEnable()
    {
        StartCoroutine(DespawnAfterDelay(settings.despawnDelay));
    }

    IEnumerator DespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PickupableFactory.ReturnToPool(this);
    }

    public void PickupThis()
    {
        StopCoroutine(DespawnAfterDelay(settings.despawnDelay));
        PickupableFactory.ReturnToPool(this);
        Debug.LogWarning(settings.type + " is picked up");
        
    }

    public PickupableItemSettings GetSettings()
    {
        return settings;
    }
}
