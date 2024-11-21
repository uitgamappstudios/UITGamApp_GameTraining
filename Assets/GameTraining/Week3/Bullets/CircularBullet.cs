using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularBullet : BaseBullet
{
    [SerializeField] private float angle;
    [SerializeField] private float radius;
    private float currentAngle;

    protected void CircleAroundPlayer()
    {
        // sin = đối / huyền, cos = kề / huyền => từ công thức mà suy ra thôi nhé!
        float xCoord = Mathf.Cos(currentAngle * Mathf.Deg2Rad) * radius;
        float yCoord = Mathf.Sin(currentAngle * Mathf.Deg2Rad) * radius;

        transform.position = new Vector2(xCoord, yCoord) + (Vector2) target.transform.position;
        currentAngle += speed * Time.deltaTime;
    }

    protected override void Start()
    {
        base.Start();
        currentAngle = angle;
    }

    private void Update()
    {
        CircleAroundPlayer();
    }
}
