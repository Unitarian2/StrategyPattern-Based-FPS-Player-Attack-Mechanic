using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAutoPickupable
{
    public void PickupThis();
    public PickupableItemSettings GetSettings();
}
