using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCircleLifeCycle : CircleLifeCycle
{
    public override ICircle CircleRef { get; set; }

    public override IEnumerator Activate(ICircle circleRef)
    {
        this.CircleRef = circleRef;
        SpawnUp();
        yield return new WaitForSeconds(CircleRef.LifeSpan);
        Shrink();
    }
}
