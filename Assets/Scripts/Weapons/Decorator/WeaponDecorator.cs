using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponDecorator : IWeapon
{
    protected IWeapon decoratedWeapon;

    public WeaponDecorator(IWeapon decoratedWeapon)
    {
        this.decoratedWeapon = decoratedWeapon;
    }

    public virtual void Fire(Vector3 attackDirection)
    {
        decoratedWeapon.Fire(attackDirection);
    }
}
