using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MagicCircle/MagicCircleData")]
public class MagicCircleDataSO : ScriptableObject
{
    public float amount;
    public StatType type;
    public float lifeSpan;
    public GameObject prefab;
}
