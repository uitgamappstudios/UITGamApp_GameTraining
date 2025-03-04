using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : IState
{
    protected BossSM bossSM;
    public BossState(BossSM _bossSM)
    {
        bossSM = _bossSM;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void FixedTick()
    {
        //
    }

    public virtual void Tick()
    {

    }
}
