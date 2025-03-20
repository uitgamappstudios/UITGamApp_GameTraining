using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 10f;     // Tốc độ tối đa
    public float acceleration = 15f; // Độ lớn gia tốc khi nhấn phím
    public float friction = 15f;     // Lực ma sát khi không nhấn phím
    public Vector3 velocity = Vector3.zero; // Vận tốc hiện tại

    public GameObject[] enemies = null; // Tập hợp enemy 
    public GameObject prefabBaseBullet;

    private float _cam_width;
    private float _cam_height;

    void Start()
    {
        // Lấy dài rộng của camera
        _cam_height = Camera.main.orthographicSize * 2;
        _cam_width = _cam_height * Camera.main.aspect;
    }

    void Update()
    {
        // Tìm các enemy trên scene 
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Move(); //Gọi hàm di chuyển biến đổi đều
        Shoot(); //Gọi hàm bắn đạn
    }

    //Định nghĩa hàm di chuyển biến đổi đều
    public void Move()
    {
        // Hướng di chuyển
        Vector3 inputDirection = Vector3.zero;

        // Kiểm tra các phím điều khiển
        if (Input.GetKey(KeyCode.W)) inputDirection.y += 1;
        if (Input.GetKey(KeyCode.S)) inputDirection.y -= 1;
        if (Input.GetKey(KeyCode.A)) inputDirection.x -= 1;
        if (Input.GetKey(KeyCode.D)) inputDirection.x += 1;

        // Tính vector đơn vị nếu có input
        Vector3 inputNormalized = inputDirection.magnitude > 0 ? inputDirection.normalized : Vector3.zero;

        // Xử lý vận tốc
        if (inputDirection.magnitude > 0)
        {
            // Tăng tốc dần khi nhấn phím
            velocity += inputNormalized * acceleration * Time.deltaTime;

            // Giới hạn tốc độ tối đa
            if (velocity.magnitude > maxSpeed)
            {
                velocity = velocity.normalized * maxSpeed;
            }
        }
        else
        {
            // Giảm tốc dần khi không nhấn phím
            float newSpeed = velocity.magnitude - (friction * Time.deltaTime);
            velocity = velocity.magnitude > 0 ? velocity.normalized * Mathf.Max(newSpeed, 0) : Vector3.zero;
        }

        // Di chuyển nhân vật
        transform.position += velocity * Time.deltaTime - (0.5f * acceleration * inputNormalized * Time.deltaTime * Time.deltaTime);


        // Tạo biến lưu giá trị vi tri mới
        Vector3 new_position = transform.position;

        // Giới hạn trái phải
        if (new_position.x < -_cam_width / 2)
            new_position.x = -_cam_width / 2;
        else if (new_position.x > _cam_width / 2)
            new_position.x = _cam_width / 2;

        // Giới hạn trên dưới
        if (new_position.y < -_cam_height / 2)
            new_position.y = -_cam_height / 2;
        else if (new_position.y > _cam_height / 2)
            new_position.y = _cam_height / 2;

        // Cập nhật vị trí mới
        transform.position = new_position;
    }

    // Định nghĩa hàm bắn đạn
    public void Shoot()
    {
        // Chỉ bắn khi vừa nhấn phím xuống 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Chọn ngẫu nhiên một kẻ địch trong danh sách
            GameObject targetEnemy = enemies[Random.Range(0, enemies.Length)];

            if (targetEnemy != null) // Đảm bảo kẻ địch vẫn còn tồn tại
            {
                // Lấy hướng từ người chơi đến kẻ địch
                Vector3 directionNormalized = (targetEnemy.transform.position - transform.position).normalized;

                // Tạo viên đạn từ prefab
                GameObject bullet = Instantiate(prefabBaseBullet, transform.position, Quaternion.identity);

                // Thiết lập hướng bay cho viên đạn
                bullet.GetComponent<Bullet>().SetDirection(directionNormalized);
            }
        }
    }
}
