using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10f;      // Tốc độ tối đa
    [SerializeField] private float acceleration = 15f; // Độ lớn gia tốc khi nhấn phím
    [SerializeField] private float friction = 15f;      // Lực ma sát khi không nhấn phím
    [SerializeField] private Vector3 velocity = Vector3.zero; // Vận tốc hiện tại

    private GameObject[] enemies = null; //Tập hợp enemy 
    [SerializeField] private GameObject prefabBaseBullet;
    [SerializeField] private float shootCooldown = 0.3f; //Chu kì bắn đạn
    private float timer = 0; 

    void Update()
    {
        //Tìm các enemy trên scene 
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Move();
        Shoot();
    }

    //Hàm di chuyển
    public void Move()
    {
        // Hướng di chuyển
        Vector3 inputDirection = new Vector3(0, 0, 0);

        // Kiểm tra các phím điều khiển
        if (Input.GetKey(KeyCode.W)) inputDirection.y += 1;
        if (Input.GetKey(KeyCode.S)) inputDirection.y -= 1;
        if (Input.GetKey(KeyCode.A)) inputDirection.x -= 1;
        if (Input.GetKey(KeyCode.D)) inputDirection.x += 1;

        // Tính độ lớn của inputDirection (magnitude)
        float inputMagnitude = Mathf.Sqrt(inputDirection.x * inputDirection.x +
                                          inputDirection.y * inputDirection.y +
                                          inputDirection.z * inputDirection.z);

        // Tính vector đơn vị (normalize) nếu inputMagnitude > 0
        Vector3 inputNormalized = Vector3.zero;
        if (inputMagnitude > 0)
            inputNormalized = inputDirection / inputMagnitude;

        // Xử lý vận tốc
        if (inputMagnitude > 0)
        {
            // Tăng tốc dần khi nhấn phím
            velocity += inputNormalized * acceleration * Time.deltaTime;

            // Tính độ lớn của vận tốc (magnitude)
            float velocityMagnitude = Mathf.Sqrt(velocity.x * velocity.x +
                                                 velocity.y * velocity.y +
                                                 velocity.z * velocity.z);

            // Giới hạn tốc độ tối đa
            if (velocityMagnitude > maxSpeed)
            {
                // Tính vector đơn vị của velocity
                Vector3 velocityNormalized = new Vector3(0, 0, 0);
                if (velocityMagnitude > 0)
                    velocityNormalized = velocity / velocityMagnitude;

                velocity = velocityNormalized * maxSpeed;
            }
        }
        else
        {
            // Giảm tốc dần khi không nhấn phím
            float velocityMagnitude = Mathf.Sqrt(velocity.x * velocity.x +
                                                 velocity.y * velocity.y +
                                                 velocity.z * velocity.z);

            float newSpeed = velocityMagnitude - (friction * Time.deltaTime);
            if (newSpeed < 0)
                newSpeed = 0;

            // Tính vector đơn vị của velocity
            Vector3 velocityNormalized = new Vector3(0, 0, 0);
            if (velocityMagnitude > 0)
                velocityNormalized = velocity / velocityMagnitude;

            velocity = velocityNormalized * newSpeed;
        }

        // Di chuyển nhân vật
        transform.position += velocity * Time.deltaTime - (0.5f * acceleration * inputNormalized * Time.deltaTime * Time.deltaTime);
    }



    public void Shoot()
    {
        timer += Time.deltaTime;

        // Chỉ bắn khi player đứng yên, có ít nhất 1 kẻ địch và đến chu kỳ bắn
        if (velocity == Vector3.zero && enemies.Length != 0 && timer >= shootCooldown)
        {
            // Chọn ngẫu nhiên một kẻ địch trong danh sách
            GameObject targetEnemy = enemies[Random.Range(0, enemies.Length)];

            if (targetEnemy != null) // Đảm bảo kẻ địch vẫn còn tồn tại
            {
                // Lấy hướng từ người chơi đến kẻ địch
                Vector3 direction = targetEnemy.transform.position - transform.position;

                // Tính độ lớn của direction (magnitude)
                float magnitude = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y + direction.z * direction.z);

                // Tính vector đơn vị (normalized) nếu magnitude > 0 
                Vector3 directionNormalized = new Vector3(0, 0, 0);
                if (magnitude > 0)
                    directionNormalized = direction / magnitude;

                // Tạo viên đạn từ prefab
                GameObject bullet = Instantiate(prefabBaseBullet, transform.position, Quaternion.identity);

                // Thiết lập hướng bay cho viên đạn
                bullet.GetComponent<Bullet>().SetDirection(directionNormalized);
            }

            timer = 0; // Đặt lại timer sau khi bắn
        }
    }


}
