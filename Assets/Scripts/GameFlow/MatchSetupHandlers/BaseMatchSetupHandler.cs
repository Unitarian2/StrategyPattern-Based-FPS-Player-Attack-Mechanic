using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMatchSetupHandler
{
    public GameSetupManager gameSetupManager;
    public BaseMatchSetupHandler(GameSetupManager gameSetupManager) 
    {
        this.gameSetupManager = gameSetupManager;
    }

    public void SetupMatch(PlayerBasicDataUI playerBasicDataUI, PickupableSpawner pickupableSpawner, CircleSpawnManager circleSpawnManager, PlayerStats playerStats, List<MagicCircleDataSO> magicCircleDataSOList)
    {
        SetupBasicUI(playerBasicDataUI);
        SetupPlayerStats(playerStats);
        SetupMagicCircleLifeSpan(magicCircleDataSOList);
        SetupCircleSpawnManager(circleSpawnManager);
        SetupPickupableSpawner(pickupableSpawner);
    }


    public void SetupBasicUI(PlayerBasicDataUI playerBasicDataUI)
    {
        playerBasicDataUI.Setup();
    }


    public void SetupPickupableSpawner(PickupableSpawner pickupableSpawner)
    {
        pickupableSpawner.StartSpawning();
    }

    public void SetupCircleSpawnManager(CircleSpawnManager circleSpawnManager)
    {
        circleSpawnManager.CircleSpawnManagerSetup();
    }


    public abstract void SetupPlayerStats(PlayerStats playerStats);

    public abstract void SetupMagicCircleLifeSpan(List<MagicCircleDataSO> magicCircleDataSOList);
    
}
