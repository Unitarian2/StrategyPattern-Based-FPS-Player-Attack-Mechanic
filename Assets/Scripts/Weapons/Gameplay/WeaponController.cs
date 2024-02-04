using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private BulletFactory bulletFactory;
    [SerializeField] private GameObject bulletSpawnParent;

    WeaponUpgradeController upgradeController;

    //Weapon Settings
    [SerializeField] private BulletSettings bulletSettings;
    public WeaponStrategy[] weaponsSlots;

    
    [SerializeField] WeaponUpgradeDefinition weaponUpgradeDefinition;
    [SerializeField] WeaponUpgradeDefinition weaponUpgradeDefinitionDamage;
    [SerializeField] WeaponUpgradeDefinition weaponUpgradeDefinitionRecklessDamage;
    public float weaponDamage;
    
    Vector3 attackDirection;

    //WeaponControllerObjectSettings
    public MeshRenderer rifleRenderer;

    //Equipped Weapon
    public WeaponStrategy currentWeapon = null;

    //Starter Owned Weapons
    public VaultableShield shield;
    public ThrowableStone stone;

    //Held Weapons
    IWeapon basicWeapon; // Tüfek, tabanca vs.
    IVaultableWeapon vaultableWeapon; // Oyuncunun önüne çektiði shield vs.
    IThrowableWeapon throwableWeapon; // Fýrlatýlabilir taþ, bomba vs.

    //Weapon Modules
    [SerializeField] private Transform barrelExitPoint;
    

    //Weapon Base Stats
    public float baseWeaponDamage = 10;
    public float baseWeaponRateOfFire = 1;

    //Weapon Current Stats
    public float currentWeaponDamage;
    public float currentWeaponRateOfFire;

    //Firing
    public float lastTimeFired = 0f;
    int layerMask = 1 << 0;

    //Gizmo Settings
    public Vector3 GizmoRaydirection = Vector3.forward;
    public float rayLength = 105f;
    public Color gizmoColor = Color.red;

    private void Awake()
    {
        basicWeapon = new BasicWeapon(this);
        GizmoRaydirection = transform.forward;
        upgradeController = GetComponent<WeaponUpgradeController>();
        rifleRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        //Baþlangýçta oyuncuya 1 shield ve 1 taþ verdik weapon olarak.
        vaultableWeapon = shield;
        throwableWeapon = stone;
        

        currentWeapon = weaponsSlots[0];

        currentWeaponDamage = baseWeaponDamage;
        currentWeaponRateOfFire = baseWeaponRateOfFire;
    }

    private void OnEnable()
    {
        ReceiveInteraction.OnWeaponUpgradePickedUp += ReceiveInteraction_OnWeaponUpgradePickedUp;
        
    }

    private void OnDisable()
    {
        ReceiveInteraction.OnWeaponUpgradePickedUp -= ReceiveInteraction_OnWeaponUpgradePickedUp;
    }

    private void ReceiveInteraction_OnWeaponUpgradePickedUp(WeaponUpgradeDefinition definition)
    {
        switch (definition.type)
        {
            case WeaponUpgradeType.Damage:

                // Hasar yükseltmesi eklenmiþ silah
                IWeapon weaponWithDamageUpgrade = new WDamageUpgrade(basicWeapon, this, definition);
                basicWeapon = weaponWithDamageUpgrade;
                upgradeController.AddToUpgradeList(definition);
                
                break;
            case WeaponUpgradeType.Firerate:
                IWeapon weaponWithRateOfFireUpgrade = new WRateOfFireUpgrade(basicWeapon, this, definition);
                basicWeapon = weaponWithRateOfFireUpgrade;
                upgradeController.AddToUpgradeList(definition);
                
                break;
        }
    }

    public void UseWeapon()
    {
        //Her atýþta Decoration süreci çalýþtýðý için hasar deðerini base deðere eþitliyoruz ardýndan decoration çalýþýyor.
        currentWeaponDamage = baseWeaponDamage;
        currentWeaponRateOfFire = baseWeaponRateOfFire;

        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Ekranýn orta noktasýný bul
        Vector3 screenCenter = new Vector3(screenWidth / 2f, screenHeight / 2f, 0f);

        // Ekranýn ortasýndan bir ray oluþtur
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        RaycastHit hit;

        Vector3 targetPoint;
        if(Physics.Raycast(ray,out hit,100f, layerMask))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        attackDirection = targetPoint - GetWeaponBarrelExitPoint();
        GizmoRaydirection = attackDirection;
        //basicWeapon.Fire(attackDirection);
        currentWeapon.FireEvent(this);
    }

    

    public void EquipWeapon(int index)
    {
        if(currentWeapon != weaponsSlots[index])
        {
            currentWeapon = weaponsSlots[index];
            SetupWeaponEquipVisuals(index);
        }  
    }

     void SetupWeaponEquipVisuals(int equippedIndex)
    {
        for(int i = 0; i < weaponsSlots.Length; i++)
        {
            if(i != equippedIndex)
            {
                weaponsSlots[i].UnequipVisually(this);
            }
            else
            {
                weaponsSlots[i].EquipVisually(this);
            }
        }
    }

    public Vector3 GetWeaponBarrelExitPoint()
    {
        return barrelExitPoint.position;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        // Gizmo olarak belirlenmiþ yöne doðru bir ray çiz
        Gizmos.DrawRay(GetWeaponBarrelExitPoint(), GizmoRaydirection * rayLength);
       // Gizmos.DrawRay(ray);
    }

    public BulletSettings GetCurrentWeaponBulletSettings()
    {
        return bulletSettings;
    }

    public Transform GetBulletSpawnParent()
    {
        return bulletSpawnParent.transform;
    }

    public IWeapon GetCurrentBulletWeapon()
    {
        return basicWeapon;
    }
    public IThrowableWeapon GetCurrentThrowableWeapon()
    {
        return throwableWeapon;
    }
    public IVaultableWeapon GetCurrentVaultableWeapon()
    {
        return vaultableWeapon;
    }

    public Vector3 GetLastAttackDirection()
    {
        return attackDirection;
    }

}
