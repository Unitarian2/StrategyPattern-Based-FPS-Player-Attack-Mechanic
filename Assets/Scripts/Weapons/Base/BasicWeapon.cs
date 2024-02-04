using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BasicWeapon : IWeapon
{
    private GameObject bulletPrefab;
    private WeaponController controller;
    public BasicWeapon(WeaponController controller) 
    {
        bulletPrefab = Resources.Load("Bullet") as GameObject;
        this.controller = controller;
    }

    public void Fire(Vector3 attackDirection)
    {
        Debug.Log("Basic shooting!");
        BulletController bullet =  BulletFactory.Spawn(controller.GetCurrentWeaponBulletSettings());
        bullet.transform.position = controller.GetWeaponBarrelExitPoint();
        bullet.transform.rotation = Quaternion.identity;
        //GameObject bullet = Object.Instantiate(bulletPrefab, controller.GetWeaponBarrelExitPoint(), Quaternion.identity);
        bullet.transform.forward = attackDirection.normalized;
        bullet.transform.parent = controller.GetBulletSpawnParent();
        bullet.StartMoving(attackDirection.normalized);
    }
}
