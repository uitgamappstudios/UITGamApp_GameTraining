using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float speed;
    [SerializeField] protected float defense;
    [SerializeField] protected float damage;

    public virtual void Attack(GameObject target) { }
    public virtual void Die(GameObject target) { }
}
