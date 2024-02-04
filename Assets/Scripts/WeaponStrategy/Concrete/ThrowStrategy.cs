using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThrowStrategy", menuName = "Weapons/ThrowStrategy")]
public class ThrowStrategy : WeaponStrategy
{
    public override void FireEvent(WeaponController weaponController)
    {
        weaponController.GetCurrentThrowableWeapon().Throw();
    }

    public override void UnequipVisually(WeaponController weaponController)
    {
        weaponController.GetCurrentThrowableWeapon().GetGameobject().SetActive(false);
    }
    public override void EquipVisually(WeaponController weaponController)
    {
        weaponController.GetCurrentThrowableWeapon().GetGameobject().SetActive(true);
    }
}
