using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BaseBullet : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    [SerializeField] protected GameObject target;

    virtual protected void Move(Vector2 direction) 
    {
        rb.velocity = direction.normalized * speed;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    virtual protected void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
}
