using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public GameObject player;
    public float speed;

    protected float maxHealth;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void Die()
    {
        GameManager.instance.score += 10;
        Destroy(gameObject);
    }
}
