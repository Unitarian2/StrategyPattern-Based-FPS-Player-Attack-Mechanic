using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletFactory : MonoBehaviour
{
    [SerializeField] bool collectionCheck = true;
    [SerializeField] int defaultCapacity = 10;
    [SerializeField] int maxPoolSize = 100;

    static BulletFactory instance;
    readonly Dictionary<BulletType, IObjectPool<BulletController>> pools = new();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static BulletController Spawn(BulletSettings s) => instance.GetRelatedPool(s)?.Get();
    public static void ReturnToPool(BulletController f) => instance.GetRelatedPool(f.settings)?.Release(f);

    IObjectPool<BulletController> GetRelatedPool(BulletSettings settings)
    {
        IObjectPool<BulletController> pool;

        if (pools.TryGetValue(settings.type, out pool)) return pool;
        pool = new ObjectPool<BulletController>(
            settings.Create,
            settings.OnGet,
            settings.OnRelease,
            settings.OnDestroyPoolObject,
            collectionCheck,
            defaultCapacity,
            maxPoolSize
            );

        pools.Add(settings.type, pool);
        return pool;
    }
}
