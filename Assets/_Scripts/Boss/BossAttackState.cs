using UnityEngine;

public class BossAttackState : IState
{
    BossSM bossSM;
    float distance;
    float timeToShoot = 0.5f;
    GameObject player;
    GameObject boss;
    float curTime = 0;
    public BossAttackState(BossSM _bossSM, GameObject player, GameObject boss, float distance, float timeToShoot)
    {
        bossSM = _bossSM;
        this.player = player;
        this.boss = boss;
        this.distance = distance;
        this.timeToShoot = timeToShoot;
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
            bossSM.MoveToPlayer();
            if (curTime >= timeToShoot)
            {
                bossSM.ShootNormalBullet();
                curTime = 0;
            }else curTime += Time.deltaTime;
            if (Vector2.Distance(boss.transform.position, player.transform.position) > distance)
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
