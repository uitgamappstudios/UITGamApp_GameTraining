using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnerState : IState
{
    BossSM bossSM;
    float distance;
    GameObject player;
    GameObject boss;
    float timeToSpawn = 0.5f;
    float curTime = 0;
    public BossSpawnerState(BossSM _bossSM, GameObject player, GameObject boss, float distance)
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
        if (curTime >= timeToSpawn)
        {
            bossSM.SpawnEnemy();
            curTime = 0;
        }else curTime += Time.deltaTime;
        if (player != null)
        {
            if (Vector2.Distance(boss.transform.position, player.transform.position) <= distance)
            {
                bossSM.ChangeState(bossSM.attack2State);
            }
        }
    }
}
