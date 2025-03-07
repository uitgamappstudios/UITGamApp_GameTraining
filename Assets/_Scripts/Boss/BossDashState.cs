
using UnityEngine;

public class BossDashState : BossState
{
    private bool isDashing = false;
    private float dashEndTime;
    private Vector3 velocity;
    
    public BossDashState(BossSM _bossSM) : base(_bossSM)
    {
        
    }

    public override void Enter()
    {
        if (bossSM.player != null)
        {
            velocity = (bossSM.player.transform.position - bossSM.transform.position).normalized * bossSM.dashSpeed;
            isDashing = true;
            dashEndTime = Time.time + bossSM.dashDuration;
            bossSM.lastDashTime = Time.time;
        }
    }

    public override void Tick()
    {
        if (bossSM.player != null)
        {
            if (Time.time >= dashEndTime)
            {
                isDashing = false;
                bossSM.ChangeState(bossSM.attack2State);
            }
            
            bossSM.transform.position += velocity * Time.deltaTime;
        }
    }
}