using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVaultableWeapon
{
    public void Vault(bool doVault);
    public GameObject GetGameobject();
}
