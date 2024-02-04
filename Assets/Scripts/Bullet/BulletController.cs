using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletController : MonoBehaviour
{
    public bool isAlive;
    Vector3 moveDirection;
    public BulletSettings settings;

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        isAlive = true;
    }

    private void OnDisable()
    {
        Debug.LogWarning("Disabled");
        isAlive = false;
    }

    public void StartMoving(Vector3 direction)
    {
        moveDirection = direction;
    }

    private void Update()
    {
        if (isAlive)
        {
            transform.position += moveDirection * Time.deltaTime * settings.moveSpeed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        BulletFactory.ReturnToPool(this);
    }
    

}

public enum BulletType
{
    BasicWeaponBullet
}
