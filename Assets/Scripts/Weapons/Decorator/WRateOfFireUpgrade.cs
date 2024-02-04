using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WRateOfFireUpgrade : WeaponDecorator
{
    WeaponController controller;
    WeaponUpgradeDefinition upgrade;
    public WRateOfFireUpgrade(IWeapon decoratedWeapon, WeaponController controller, WeaponUpgradeDefinition upgrade) : base(decoratedWeapon)
    {
        this.controller = controller;
        this.upgrade = upgrade;
    }

    public override void Fire(Vector3 attackDirection)
    {
        controller.currentWeaponRateOfFire += upgrade.value;
        base.Fire(attackDirection);
        
        Debug.Log("Rate of fire upgraded!");
    }
}
