using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10f;      // Tốc độ tối đa
    [SerializeField] private float acceleration = 15f; // Gia tốc khi nhấn phím
    [SerializeField] private float friction = 15f;      // Lực ma sát khi không nhấn phím
    [SerializeField] private Vector3 velocity = Vector3.zero; // Vận tốc hiện tại

    private GameObject[] enemies = null; //Tập hợp enemy 
    [SerializeField] private GameObject prefabBaseBullet;
    [SerializeField] private float shootCooldown = 0.3f; //Chu kì bắn đạn
    private float timer = 0;
    
    private float _cam_width;
    private float _cam_height;
    
     

    void Start()
    {
        // Lấy dài rộng của camera
        _cam_height = Camera.main.orthographicSize * 2;
        _cam_width = _cam_height * Camera.main.aspect;

        //Tìm các enemy trên scene 
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        Move_2();
        Shoot();
    }

    //Hàm di chuyển
    public void Move()
    {
        //Hướng di chuyển
        Vector3 inputDirection = Vector3.zero;

        // Kiểm tra các phím điều khiển
        if (Input.GetKey(KeyCode.W)) inputDirection.y += 1;
        if (Input.GetKey(KeyCode.S)) inputDirection.y -= 1;
        if (Input.GetKey(KeyCode.A)) inputDirection.x -= 1;
        if (Input.GetKey(KeyCode.D)) inputDirection.x += 1;

        // Tính vận tốc dựa trên gia tốc hoặc ma sát
        if (inputDirection != Vector3.zero)
        {
            // Tăng tốc dần khi nhấn phím
            velocity += inputDirection.normalized * acceleration * Time.deltaTime; //normalized giúp đảm bảo độ dài luôn là 1, tránh tốc độ di chuyển nhanh hơn khi đi chéo
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed); // Giới hạn tốc độ tối đa
        }
        else
        {
            // Giảm tốc dần khi không nhấn phím
            velocity = Vector3.MoveTowards(velocity, Vector3.zero, friction * Time.deltaTime); 
        }

        // Di chuyển nhân vật
        transform.position += velocity * Time.deltaTime;
        
    }
    
    //Hàm di chuyển
    public void Move_2()
    {
        //Hướng di chuyển
        Vector3 inputDirection = Vector3.zero;

        // Kiểm tra các phím điều khiển
        if (Input.GetKey(KeyCode.W)) inputDirection.y += 1;
        if (Input.GetKey(KeyCode.S)) inputDirection.y -= 1;
        if (Input.GetKey(KeyCode.A)) inputDirection.x -= 1;
        if (Input.GetKey(KeyCode.D)) inputDirection.x += 1;

        // Tính vận tốc dựa trên gia tốc hoặc ma sát
        if (inputDirection != Vector3.zero)
        {
            // Tăng tốc dần khi nhấn phím
            velocity += inputDirection.normalized * acceleration * Time.deltaTime; //normalized giúp đảm bảo độ dài luôn là 1, tránh tốc độ di chuyển nhanh hơn khi đi chéo
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed); // Giới hạn tốc độ tối đa
        }
        else
        {
            // Giảm tốc dần khi không nhấn phím
            velocity = Vector3.MoveTowards(velocity, Vector3.zero, friction * Time.deltaTime); 
        }

        // Di chuyển nhân vật
        Vector3 new_positon = transform.position;
        // Giới hạn trái phải
        new_positon.x = Mathf.Min(
            Mathf.Max(-_cam_width / 2, new_positon.x + velocity.x * Time.deltaTime),
            _cam_width / 2
        );
        // Giới hạn trên dưới
        new_positon.y = Mathf.Min(
            Mathf.Max(-_cam_height / 2, new_positon.y + velocity.y * Time.deltaTime),
            _cam_height / 2
        );
        transform.position = new_positon;
    }

    public void Shoot()
    {
        timer += Time.deltaTime;

        // Chỉ bắn khi player đứng yên, có ít nhất 1 kẻ địch và đến chu kì bắn
        if (velocity == Vector3.zero && enemies.Length != 0  && timer >= shootCooldown)
        {
            // Chọn ngẫu nhiên một kẻ địch trong danh sách
            GameObject targetEnemy = enemies[Random.Range(0, enemies.Length)];

            if (targetEnemy != null) // Đảm bảo kẻ địch vẫn còn tồn tại
            {
                // Tạo viên đạn từ prefab
                GameObject bullet = Instantiate(prefabBaseBullet, transform.position, Quaternion.identity);

                // Lấy hướng từ người chơi đến kẻ địch
                Vector3 direction = (targetEnemy.transform.position - transform.position).normalized;

                // Thiết lập hướng bay cho viên đạn
                bullet.GetComponent<BaseBullet>().SetDirection(direction);
            }

            timer = 0; //Đặt lại timer sau khi bắn
        }
    }
}
