using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDistanceBasedCircle
{
    public Collider Collider { get; set; }
    public StatType Type { get; set; }
    public float Amount { get; set; }
    public float LifeSpan { get; set; }
    public float GetCalculatedAmountByPos(Vector3 receiverPos);
    public void StartLifeCycle(ICircle circle);
    public GameObject GetGameObject();
    public void Despawn();
}
