using System.Runtime.Serialization;
using UnityEngine;
using static System.Net.WebRequestMethods;

public class PlayerController : MonoBehaviour
{
    public Vector3 velocity = Vector3.zero; // Vận tốc hiện tại

    public GameObject[] enemies = null; // Tập hợp enemy 

    private float _cam_width;
    private float _cam_height;

    public float currHealth;

    public PlayerConfig playerConfig;

    public bool isWin = false;

    public Joystick joystick;

    public VoidPublisherSO winPublisher;
    void Start()
    {
        currHealth = playerConfig.maxHealth;
        // Lấy dài rộng của camera
        _cam_height = Camera.main.orthographicSize * 2;
        _cam_width = _cam_height * Camera.main.aspect;
    }

    void Update()
    {
        // Tìm các enemy trên scene 
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Kiem tra so luong enemy chien thang
        if (isWin == false && enemies.Length == 0)
        {
            //UIManager.instance.Win();
            winPublisher.RaiseEvent();
            isWin = true;
        }

        Move(); //Gọi hàm di chuyển biến đổi đều
        Shoot(); //Gọi hàm bắn đạn  
    }
    public void ModifyHealth(float health)
    {
        currHealth += health;
        if (currHealth > playerConfig.maxHealth)
        {
            currHealth = playerConfig.maxHealth;
        }
        if (currHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("GameOver!");
        Destroy(gameObject);

        //UI Gameover
        UIManager.instance.Lose();
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

        // Get direction from joystick 
        inputDirection.x = joystick.Horizontal;
        inputDirection.y = joystick.Vertical;

        // Tính vector đơn vị nếu có input
        Vector3 inputNormalized = inputDirection.magnitude > 0 ? inputDirection.normalized : Vector3.zero;

        // Xử lý vận tốc
        if (inputDirection.magnitude > 0)
        {
            // Tăng tốc dần khi nhấn phím
            velocity += inputNormalized * playerConfig.acceleration * Time.deltaTime;

            // Giới hạn tốc độ tối đa
            if (velocity.magnitude > playerConfig.maxSpeed)
            {
                velocity = velocity.normalized * playerConfig.maxSpeed;
            }
        }
        else
        {
            // Giảm tốc dần khi không nhấn phím
            float newSpeed = velocity.magnitude - (playerConfig.friction * Time.deltaTime);
            velocity = velocity.magnitude > 0 ? velocity.normalized * Mathf.Max(newSpeed, 0) : Vector3.zero;
        }

        // Di chuyển nhân vật
        transform.position += velocity * Time.deltaTime - (0.5f * playerConfig.acceleration * inputNormalized * Time.deltaTime * Time.deltaTime);


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
            if (enemies.Length != 0)
            {
                // Chọn ngẫu nhiên một kẻ địch trong danh sách
                GameObject targetEnemy = enemies[Random.Range(0, enemies.Length)];

                if (targetEnemy != null) // Đảm bảo kẻ địch vẫn còn tồn tại
                {
                    // Lấy hướng từ người chơi đến kẻ địch
                    Vector3 directionNormalized = (targetEnemy.transform.position - transform.position).normalized;

                    // Tạo viên đạn từ prefab
                    var bullet = BulletPooling.Instance.GetBullet(BulletType.PlayerBullet);
                    bullet.transform.position = transform.position;

                    // Thiết lập hướng bay cho viên đạn
                    bullet.SetDirection(directionNormalized);
                }
            }
        }
    }
}
