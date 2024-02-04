using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCircle : BaseCircle, ICircle
{
    
    
    public float Amount { get; set; }
    public StatType Type { get; set; }
    public float LifeSpan { get; set; }



    public float GetCalculatedAmount()
    {
        return Amount;
    }

   

    public void StartLifeCycle()
    {
        CircleLifeCycle circleBehaviour = new HealCircleLifeCycle();
        
        StartCoroutine(circleBehaviour.Activate(this));
    }

    private void Start()
    {
        Amount = m_MagicCircleDataSO.amount;
        Type = m_MagicCircleDataSO.type;
        LifeSpan = m_MagicCircleDataSO.lifeSpan;
    }
}
