using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CircleLifeCycle 
{
    public abstract IEnumerator Activate(ICircle circleRef);//Subclass kendi versiyonunu tanýmlamalý

    public abstract ICircle CircleRef { get; set; }

    protected void SpawnUp()
    {
        Debug.Log("Circle Spawn Up");
        CircleRef.GetGameObject().transform.parent.gameObject.transform.localScale = Vector3.zero;
        if (ObjectPuppetMaster.Instance != null)
        {
            ObjectPuppetMaster.Instance.StartCoroutine(ObjectPuppetMaster.Instance.ScaleTo(CircleRef.GetGameObject().transform.parent.gameObject, Vector3.one, 0.5f));
        }
    }

    protected void Shrink()
    {
        Debug.Log("Circle Shrink");
        if (ObjectPuppetMaster.Instance != null)
        {
            ObjectPuppetMaster.Instance.StartCoroutine(ObjectPuppetMaster.Instance.ScaleTo(CircleRef.GetGameObject().transform.parent.gameObject, Vector3.zero, 5f, () =>
            {
                Despawn();
            }));
        }
    }

    protected void Despawn()
    {
        CircleRef.Despawn();
        Debug.Log("Circle Despawn");
    }
}
