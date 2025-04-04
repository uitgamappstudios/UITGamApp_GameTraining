using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public PlayerController player;
    public float speed;

    public float maxHealth;
    public float currentHealth;

    protected virtual void Start()
    {
        player = GameManager.instance.player;
        currentHealth = maxHealth;
    }
    protected void Die()
    {
        GameManager.instance.score++;
        Destroy(gameObject);
    }

    public void Move()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        Vector3 velocity = direction.normalized * speed;
        this.transform.position += velocity * Time.deltaTime;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    public void ModifyHealth(float delta)
    {
        currentHealth += delta;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        if (currentHealth < 0)
            Die();
    }
}
