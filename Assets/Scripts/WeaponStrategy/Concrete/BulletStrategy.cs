using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletStrategy",menuName = "Weapons/BulletStrategy")]
public class BulletStrategy : WeaponStrategy
{
    

    public override void FireEvent(WeaponController weaponController)
    {
        weaponController.GetCurrentBulletWeapon().Fire(weaponController.GetLastAttackDirection());

    }

    public override void UnequipVisually(WeaponController weaponController)
    {
        weaponController.rifleRenderer.enabled = false;
        weaponController.transform.GetChild(0).gameObject.SetActive(false);
    }
    public override void EquipVisually(WeaponController weaponController)
    {
        weaponController.rifleRenderer.enabled = true;
        weaponController.transform.GetChild(0).gameObject.SetActive(true);
    }
}
