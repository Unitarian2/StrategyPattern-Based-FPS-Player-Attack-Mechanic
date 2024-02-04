using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialToRegularCircleAdapter : ICircle
{
    Vector3 receiverPos;
    IDistanceBasedCircle distanceBasedCircle;
    public SpecialToRegularCircleAdapter(Vector3 receiverPos, StatType statType, float Amount, IDistanceBasedCircle distanceBasedCircle, float lifeSpan)
    {
        this.receiverPos = receiverPos;
        this.Type = statType;
        this.Amount = Amount;
        this.distanceBasedCircle = distanceBasedCircle;
        LifeSpan = lifeSpan;
    }
    public StatType Type { get; set; }
    public float Amount { get; set; }

    public float LifeSpan { get; set; }

    public void Despawn()
    {
        distanceBasedCircle.Despawn();
    }

    public float GetCalculatedAmount()
    {
        return distanceBasedCircle.GetCalculatedAmountByPos(receiverPos);
    }

    public GameObject GetGameObject()
    {
        return distanceBasedCircle.GetGameObject();
    }

    public void StartLifeCycle()
    {
        distanceBasedCircle.StartLifeCycle(this);
    }
}
