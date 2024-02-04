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

    
    [SerializeField] WeaponUpgradeDefinition weaponUpgradeDefinition;
    [SerializeField] WeaponUpgradeDefinition weaponUpgradeDefinitionDamage;
    [SerializeField] WeaponUpgradeDefinition weaponUpgradeDefinitionRecklessDamage;
    public float weaponDamage;
    IWeapon basicWeapon;

    //Weapon Modules
    [SerializeField] private Transform barrelExitPoint;
    [SerializeField] private GameObject weaponUpgradeSection;

    //Weapon Base Stats
    public float baseWeaponDamage = 10;
    public float baseWeaponRateOfFire = 1;

    //Weapon Current Stats
    public float currentWeaponDamage;
    public float currentWeaponRateOfFire;

    //Firing
    private float lastTimeFired = 0f;
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
    }

    private void Start()
    {
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

    private void Update()
    {
        // Ekran boyutlarýný al
        

        // Ray'i görselleþtirmek için Debug.DrawLine kullanabilirsiniz
        //Debug.DrawLine(ray.origin, ray.origin + ray.direction * 10f, Color.blue);
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
                //IWeaponUpgrade newUpgrade = WeaponUpgradeFactory.Create(definition, null);
                //if (newUpgrade is WeaponUpgrader upgrader)
                //{
                //    upgrader.Upgrade(currentWeaponUpgrade);
                //    currentWeaponUpgrade = upgrader;
                //}
                break;
            case WeaponUpgradeType.Firerate:
                IWeapon weaponWithRateOfFireUpgrade = new WRateOfFireUpgrade(basicWeapon, this, definition);
                basicWeapon = weaponWithRateOfFireUpgrade;
                upgradeController.AddToUpgradeList(definition);
                //IWeaponUpgrade newUpgrade2 = WeaponUpgradeFactory.Create(definition, playerMovement);
                //if (newUpgrade2 is WeaponUpgrader upgrader2)
                //{
                //    upgrader2.Upgrade(currentWeaponUpgrade);
                //    currentWeaponUpgrade = upgrader2;
                //}
                break;
        }

        //weaponDamage = currentWeaponUpgrade.GetModifier();

        // Oluþturulan temel silah
    }

    void FireWeapon()
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

        //Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
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

        Vector3 attackDirection = targetPoint - GetWeaponBarrelExitPoint();
        GizmoRaydirection = attackDirection;
        basicWeapon.Fire(attackDirection);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && Time.time >= lastTimeFired + (1 / currentWeaponRateOfFire)) 
        {
            FireWeapon();
            lastTimeFired = Time.time;
        }

        //Debug.Log(transform.forward);
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

}
