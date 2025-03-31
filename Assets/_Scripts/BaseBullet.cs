using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    protected Vector3 direction;
    public float speed;

    public float damage;
    //Thiet lap huong bay cua vien dan
    public virtual void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
