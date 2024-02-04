using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInputController : MonoBehaviour
{
    WeaponController weaponController;
    
    void Start()
    {
        weaponController = GetComponent<WeaponController>();
    }

    private void Update()
    {
        if(weaponController != null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                weaponController.EquipWeapon(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                weaponController.EquipWeapon(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                weaponController.EquipWeapon(2);
            }

            if (Input.GetMouseButtonDown(0) && weaponController.currentWeapon == weaponController.weaponsSlots[1])//Throw
            {
                weaponController.UseWeapon();
            }
            else if (Input.GetMouseButtonUp(0) && weaponController.currentWeapon == weaponController.weaponsSlots[2])//Vault
            {
                Debug.LogWarning("Vault Pressed");
                weaponController.UseWeapon();
            }
        }

        
    }

    void FixedUpdate()
    {
        if (weaponController != null)
        {
            if (Input.GetMouseButton(0) && weaponController.currentWeapon == weaponController.weaponsSlots[0])//Bullet
            {
                if (Time.time >= weaponController.lastTimeFired + (1 / weaponController.currentWeaponRateOfFire))
                {
                    weaponController.UseWeapon();
                    weaponController.lastTimeFired = Time.time;
                }
            }
            
        }
        
    }
}
