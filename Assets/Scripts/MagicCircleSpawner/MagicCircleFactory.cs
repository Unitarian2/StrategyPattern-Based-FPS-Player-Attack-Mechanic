using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MagicCircleFactory : MonoBehaviour
{
    [SerializeField] private List<GameObject> circleToGet;
    [SerializeField] private Transform circleParent;
    
    public ICircle GetMagicCircle(Vector3 spawnPos)
    {
        GameObject clone = Instantiate(GetRandomGameObject(), spawnPos, Quaternion.identity, circleParent);
        clone.SetActive(false);
        ICircle circle = clone.GetComponentInChildren<ICircle>();

        return circle;
    }

    

    GameObject GetRandomGameObject()
    {
        int index = Random.Range(0, circleToGet.Count);
        return circleToGet[index];
    }
}


