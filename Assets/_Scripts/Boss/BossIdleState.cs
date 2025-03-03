using UnityEngine;

public class BossIdleState : IState
{
    BossSM bossSM;
    float distance;
    GameObject player;
    GameObject boss;
    public BossIdleState(BossSM _bossSM, GameObject player, GameObject boss,  float distance)
    {
        bossSM = _bossSM;
        this.player = player;
        this.boss = boss;
        this.distance = distance;
    }

    public void Enter()
    {

    }

    public void Exit()
    {
        
    }

    public void FixedTick()
    {
        //
    }

    public void Tick()
    { 
        if (player != null)
        {
            if (Vector2.Distance(boss.transform.position, player.transform.position) <= distance)
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
