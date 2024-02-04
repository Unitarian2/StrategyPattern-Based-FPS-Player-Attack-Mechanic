using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private PlayerBasicDataUI playerBasicDataUI;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private List<MagicCircleDataSO> magicCircleDataSOs;
    [SerializeField] private CircleSpawnManager circleSpawnManager;
    [SerializeField] private PickupableSpawner pickupableSpawner;

    public MatchType matchType;

    // Start is called before the first frame update
    void Start()
    {
        BaseMatchSetupHandler matchSetupHandler = new EasyMatchSetupHandler(this);//Match Type eþleþmesinde bir hata olursa default'umuz Easy Match

        switch (matchType)
        {
            case MatchType.Easy:
                matchSetupHandler = new EasyMatchSetupHandler(this);
                
                break;
            case MatchType.CrazyCircles:
                matchSetupHandler = new CrazyCirclesSetupHandler(this);
                break;
            case MatchType.FragilePlayer:
                matchSetupHandler = new FragilePlayerSetupHandler(this);
                break;
            case MatchType.Hard:
                matchSetupHandler = new HardMatchSetupHandler(this);
                break;
        }

        matchSetupHandler.SetupMatch(playerBasicDataUI, pickupableSpawner, circleSpawnManager, playerStats, magicCircleDataSOs);
        
    }


}

public enum MatchType
{
    Easy,
    CrazyCircles,
    FragilePlayer,
    Hard
}
