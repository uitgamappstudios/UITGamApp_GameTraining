using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : BaseEnemy
{
    public override void Die()
    {
        LevelUpManager.Instance.AddExp(1);
        EnemyManager.Instance.RemoveEnemy(this);
        base.Die();
    }
}
