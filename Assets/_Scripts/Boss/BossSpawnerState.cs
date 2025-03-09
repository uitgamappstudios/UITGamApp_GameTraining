
using UnityEngine;

public class BossSpawnerState : BossState
{
    float timeToSpawn = 2f;
    float curTime = 0;
    public BossSpawnerState(BossSM _bossSM) : base(_bossSM)
    {
        bossSM = _bossSM;
    }

    public override void Tick()
    {
        if (curTime >= timeToSpawn)
        {
            bossSM.SpawnEnemy();
            curTime = 0;
        }else curTime += Time.deltaTime;
        if (bossSM.player != null)
        {
            if (Vector2.Distance(bossSM.transform.position, bossSM.player.transform.position) <= bossSM.attackRange)
            {
                if (Time.time >= bossSM.lastDashTime + bossSM.dashCooldown)
                {
                    bossSM.ChangeState(bossSM.dashState);
                }
                else
                {
                    bossSM.ChangeState(bossSM.attack2State);
                }
            }
        }
    }
}
