using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMatchSetupHandler : BaseMatchSetupHandler
{
    public EasyMatchSetupHandler(GameSetupManager gameSetupManager) : base(gameSetupManager) { }

    public override void SetupMagicCircleLifeSpan(List<MagicCircleDataSO> magicCircleDataSOList)
    {
        foreach(MagicCircleDataSO data in magicCircleDataSOList)
        {
            switch (data.type)
            {
                case StatType.Health:
                    data.lifeSpan *= 1.5f;
                    break;
                case StatType.Mana:
                    data.lifeSpan *= 1.5f;
                    break;
                case StatType.Damage:
                    data.lifeSpan *= 0.5f;
                    break;
                case StatType.None:
                    break;
            }
        }
    }

    public override void SetupPlayerStats(PlayerStats playerStats)
    {
        playerStats.maxHealth *= 1.25f;
        playerStats.maxMana *= 1.25f;
    }


}
