using UnityEngine;

public class BossIdleState : BossState
{
    public BossIdleState(BossSM _bossSM) : base(_bossSM)
    {
        
    }

    public override void Tick()
    { 
        if (bossSM.player != null)
        {
            if (Vector2.Distance(bossSM.transform.position, bossSM.transform.position) <= bossSM.attackRange)
            {
                if (bossSM.GetHealthPercentage() <= 0.5)
                {
                    bossSM.GetBigger();
                    bossSM.ChangeState(bossSM.attack2State);
                }
                else bossSM.ChangeState(bossSM.attackState);
            }
        }
    }
}
