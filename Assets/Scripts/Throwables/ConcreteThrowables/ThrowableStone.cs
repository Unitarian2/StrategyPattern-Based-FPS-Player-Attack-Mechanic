using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableStone : MonoBehaviour, IThrowableWeapon
{
    GameObject prefab;
    public float speed;

    private void Start()
    {
        prefab = Resources.Load("StoneSpawn") as GameObject;
    }
    public void Throw()
    {
        GameObject spawn = Instantiate(prefab);
        spawn.transform.position = transform.position;
        spawn.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    public GameObject GetGameobject()
    {
        return gameObject;
    }
}
