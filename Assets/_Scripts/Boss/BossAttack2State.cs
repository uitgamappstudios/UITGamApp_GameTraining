using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack2State : IState
{
    BossSM bossSM;
    float distance;
    float timeToShoot;
    GameObject player;
    GameObject boss;
    float curTime = 0;
    public BossAttack2State(BossSM _bossSM, GameObject player, GameObject boss, float distance, float timeToShoot)
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
            if(curTime >= timeToShoot)
            {
                bossSM.ShootMultipleBullet();
                curTime = 0;
            }else curTime += Time.deltaTime;

            if (Vector2.Distance(boss.transform.position, player.transform.position) > distance)
            {
                bossSM.ChangeState(bossSM.spawnerState);
            }
        }
    }
}
