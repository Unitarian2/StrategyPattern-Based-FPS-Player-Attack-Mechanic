using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bullet/Bullet Settings")]
public class BulletSettings : ScriptableObject
{
    public float moveSpeed;
    public BulletType type;
    public GameObject prefab;

    public virtual BulletController Create()
    {
        GameObject go = Instantiate(prefab);
        go.SetActive(false);
        go.name = prefab.name;

        var flyweight = go.AddComponent<BulletController>();
        flyweight.settings = this;

        return flyweight;
    }

    public virtual void OnGet(BulletController f) => f.gameObject.SetActive(true);
    public virtual void OnRelease(BulletController f) => f.gameObject.SetActive(false);
    public virtual void OnDestroyPoolObject(BulletController f) => Destroy(f.gameObject);
}
