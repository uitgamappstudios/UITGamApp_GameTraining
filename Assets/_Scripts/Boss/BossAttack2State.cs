using UnityEngine;

public class BossAttack2State : BossState
{
    float curTime = 0;
    public BossAttack2State(BossSM _bossSM) : base(_bossSM)
    {
        bossSM = _bossSM;
    }

    public override void Tick()
    {
        if (bossSM.player != null)
        {
            bossSM.MoveToPlayer();
            if(curTime >= bossSM.timeToShoot * 0.75f)
            {
                bossSM.ShootMultipleBullet();
                curTime = 0;
            }else curTime += Time.deltaTime;

            if (Vector2.Distance(bossSM.transform.position, bossSM.player.transform.position) > bossSM.attackRange * 1.75f)
            {
                bossSM.ChangeState(bossSM.spawnerState);
            }
        }
    }
}
