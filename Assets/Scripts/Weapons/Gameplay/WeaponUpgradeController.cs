using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponUpgradeController : MonoBehaviour
{
    public List<WeaponUpgradeDefinition> upgradeList;
    public List<WeaponUpgradeDefinition> upgradeListShowable;
    [SerializeField] private Transform upgradeVisualSocket;
    private int maxShowableUpgrade;
    private float offsetForVisuals;


    private void Awake()
    {
        upgradeList = new List<WeaponUpgradeDefinition>();
        maxShowableUpgrade = 5;
        offsetForVisuals = 0.05f;
    }

    public void AddToUpgradeList(WeaponUpgradeDefinition newUpgradeDefinition)
    {
        upgradeList.Add(newUpgradeDefinition);
        upgradeListShowable.Add(newUpgradeDefinition);

        if (upgradeListShowable.Count > maxShowableUpgrade)
        {
            RemoveFromUpgradeListShowable(upgradeListShowable.First());
        }
        else
        {
            UpdateWeaponUpgradeVisuals();
        }

        
        
    }

    private void RemoveFromUpgradeListShowable(WeaponUpgradeDefinition upgradeDefinition)
    {
        upgradeListShowable.Remove(upgradeDefinition);
        UpdateWeaponUpgradeVisuals();
    }

    private void UpdateWeaponUpgradeVisuals()
    {
        ClearSocket();

        float posZ = 0f;
        foreach (var upgrade in upgradeListShowable) 
        { 
            //Vector3 spawnPos = new Vector3 (upgradeVisualSocket.position.x, upgradeVisualSocket.position.y, upgradeVisualSocket.position.z + posZ);
            GameObject obj = Instantiate(upgrade.prefab, upgradeVisualSocket.transform.position, Quaternion.identity ,upgradeVisualSocket);
            obj.transform.localRotation = Quaternion.Euler(Vector3.zero);
            obj.transform.Translate(new Vector3(0f,0f,-posZ));
            posZ += offsetForVisuals;
        }
    }

    private void ClearSocket()
    {
        int childCount = upgradeVisualSocket.childCount;

        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = upgradeVisualSocket.GetChild(i);
            Destroy(child.gameObject);
        }

    }
}
