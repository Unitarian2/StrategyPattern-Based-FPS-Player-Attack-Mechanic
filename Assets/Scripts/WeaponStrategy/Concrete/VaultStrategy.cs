using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VaultStrategy", menuName = "Weapons/VaultStrategy")]
public class VaultStrategy : WeaponStrategy
{
    public bool isVaulted = false;
    public override void FireEvent(WeaponController weaponController)
    {
        Debug.LogWarning("Vault Event Fired, isVaulted => "+isVaulted);
        weaponController.GetCurrentVaultableWeapon().Vault(!isVaulted);
        isVaulted = !isVaulted;
    }

    public override void UnequipVisually(WeaponController weaponController)
    {
        weaponController.GetCurrentVaultableWeapon().GetGameobject().SetActive(false);
    }
    public override void EquipVisually(WeaponController weaponController)
    {
        weaponController.GetCurrentVaultableWeapon().GetGameobject().SetActive(true);
    }
}
