using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCircle : MonoBehaviour
{
    public MagicCircleDataSO m_MagicCircleDataSO;

    public void Despawn()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

}
