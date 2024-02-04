using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponUpgrade", menuName ="Weapon/WeaponUpgradeDefinition")]
public class WeaponUpgradeDefinition : ScriptableObject
{
    public float value = 10;
    public WeaponUpgradeType type = WeaponUpgradeType.None;
    public GameObject prefab;
}

public enum WeaponUpgradeType
{
    None,
    Damage,
    Firerate
}
