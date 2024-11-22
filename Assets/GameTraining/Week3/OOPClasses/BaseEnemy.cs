using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    private float currentHealth;
    [SerializeField] protected float health;
    [SerializeField] protected float speed;
    [SerializeField] protected float defense;
    [SerializeField] protected float damage;

    public virtual void ModifyHealth(float delta)
    {
        health += delta;
        if (currentHealth < 0)
            Die();
    }
    public virtual void Attack(GameObject target) { }
    public virtual void Die() 
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        currentHealth = health;
    }
}
