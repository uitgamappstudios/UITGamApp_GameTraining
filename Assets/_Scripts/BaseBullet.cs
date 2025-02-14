using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BaseBullet : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed;

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    void Update()
    {
        // Di chuyển viên đạn theo hướng đã được thiết lập
        transform.position += direction * speed * Time.deltaTime;
    }
}
