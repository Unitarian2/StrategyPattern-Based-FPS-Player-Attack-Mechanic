using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponStrategy : ScriptableObject
{
    public abstract void FireEvent(WeaponController weaponController);
    public abstract void UnequipVisually(WeaponController weaponController);
    public abstract void EquipVisually(WeaponController weaponController);
}
