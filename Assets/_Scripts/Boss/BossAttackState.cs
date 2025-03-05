using UnityEngine;

public class BossAttackState : BossState
{
    float curTime = 0;
    public BossAttackState(BossSM _bossSM) : base(_bossSM)
    {
        bossSM = _bossSM;
    }
    public override void Tick()
    {
        if (bossSM.player != null)
        {
            bossSM.MoveToPlayer();
            if (curTime >= bossSM.timeToShoot)
            {
                bossSM.ShootNormalBullet();
                curTime = 0;
            }else curTime += Time.deltaTime;
            if (Vector2.Distance(bossSM.transform.position, bossSM.player.transform.position) > bossSM.attackRange)
            {
                if (bossSM.GetHealthPercentage() <= 0.5)
                {
                    bossSM.GetBigger();
                    bossSM.ChangeState(bossSM.spawnerState);
                }
                else bossSM.ChangeState(bossSM.idleState);
            }
            
        }
    }
}
