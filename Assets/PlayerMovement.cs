using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private BaseBullet bullet;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x: horizontal, y: vertical, z: 0) * Time.deltaTime * moveSpeed;
        transform.position += move;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            BaseBullet returnBullet = BulletManager.Instance.Shoot(bullet);
            Debug.Log(returnBullet);
            returnBullet.BulletInit(transform.position, direction);
        }
    }
}
