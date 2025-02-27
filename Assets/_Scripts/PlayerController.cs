using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 10f;      // Tốc độ tối đa
    [SerializeField] private float _acceleration = 15f; // Độ lớn gia tốc khi nhấn phím
    [SerializeField] private float _friction = 15f;      // Lực ma sát khi không nhấn phím
    [SerializeField] private float _health;     // Máu của player   
    [SerializeField] private Vector3 _velocity = Vector3.zero; // Vận tốc hiện tại
    public Vector3 Velocity => _velocity;

    private GameObject[] _enemies = null; //Tập hợp enemy 
    [SerializeField] private float _shootCooldown = 0.3f; //Chu kì bắn đạn
    private float _timer = 0;

    private float _cam_width;
    private float _cam_height;
    private float _currentHealth;
    private GameObject _target;
    private bool _isEnable;

    private bool _enemiesCleared = false;
    public bool EnemiesCleared => _enemiesCleared;

    void Start()
    {
        _isEnable = true;
        _enemiesCleared = false;

        // Khởi tạo lượng máu cho player
        _currentHealth = _health;

        // Lấy dài rộng của camera
        _cam_height = Camera.main.orthographicSize * 2;
        _cam_width = _cam_height * Camera.main.aspect;
    }

    void Update()
    {
        if (_isEnable)
        {
            Move();
            Shoot();
        } 
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

        // Nếu di chuyển thì không theo dõi target nữa
        if (inputDirection.x != 0 || inputDirection.y != 0) _target = null;

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
            _velocity += inputNormalized * _acceleration * Time.deltaTime;

            // Tính độ lớn của vận tốc (magnitude)
            float velocityMagnitude = Mathf.Sqrt(_velocity.x * _velocity.x +
                                                 _velocity.y * _velocity.y +
                                                 _velocity.z * _velocity.z);

            // Giới hạn tốc độ tối đa
            if (velocityMagnitude > _maxSpeed)
            {
                // Tính vector đơn vị của velocity
                Vector3 velocityNormalized = new Vector3(0, 0, 0);
                if (velocityMagnitude > 0)
                    velocityNormalized = _velocity / velocityMagnitude;

                _velocity = velocityNormalized * _maxSpeed;
            }
        }
        else
        {
            // Giảm tốc dần khi không nhấn phím
            float velocityMagnitude = Mathf.Sqrt(_velocity.x * _velocity.x +
                                                 _velocity.y * _velocity.y +
                                                 _velocity.z * _velocity.z);

            float newSpeed = velocityMagnitude - (_friction * Time.deltaTime);
            if (newSpeed < 0)
                newSpeed = 0;

            // Tính vector đơn vị của velocity
            Vector3 velocityNormalized = new Vector3(0, 0, 0);
            if (velocityMagnitude > 0)
                velocityNormalized = _velocity / velocityMagnitude;

            _velocity = velocityNormalized * newSpeed;
        }

        // Di chuyển nhân vật
        transform.position += _velocity * Time.deltaTime - (0.5f * _acceleration * inputNormalized * Time.deltaTime * Time.deltaTime);

        //Giới hạn vị trí Player
        Vector3 new_positon = transform.position;
        // Giới hạn trái phải
        new_positon.x = Mathf.Min(Mathf.Max(-_cam_width / 2, new_positon.x + _velocity.x * Time.deltaTime), _cam_width / 2);
        // Giới hạn trên dưới
        new_positon.y = Mathf.Min(Mathf.Max(-_cam_height / 2, new_positon.y + _velocity.y * Time.deltaTime), _cam_height / 2);
        transform.position = new_positon;
    }

    // Hàm tìm kiếm target
    private void FindTarget()
    {
        // Tìm các enemy trên scene 
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Nếu không còn kẻ địch thì chiến thắng
        if (_enemies.Length == 0)
        {
            Win();
            return;
        }
        _target = _enemies[Random.Range(0, _enemies.Length)];
    }

    public void Shoot()
    {
        _timer += Time.deltaTime;

        // Chỉ bắn khi player đứng yên, có ít nhất 1 kẻ địch và đến chu kỳ bắn
        if (_velocity == Vector3.zero && _timer >= _shootCooldown)
        {
            if (_target == null) FindTarget();
            // Đảm bảo còn kẻ địch
            if (_target == null) return;

            // Lấy hướng từ người chơi đến kẻ địch
            Vector3 direction = _target.transform.position - transform.position;

            // Tính độ lớn của direction (magnitude)
            float magnitude = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y + direction.z * direction.z);

            // Tính vector đơn vị (normalized) nếu magnitude > 0 
            Vector3 directionNormalized = new Vector3(0, 0, 0);
            if (magnitude > 0)
                directionNormalized = direction / magnitude;

            // Tạo viên đạn từ prefab
            PlayerBullet bullet = (PlayerBullet)BulletManager.Instance.GetBullet(BulletManager.BulletType.PlayerBullet);
            bullet.transform.position = transform.position;

            // Thiết lập hướng bay cho viên đạn
            bullet.SetDirection(directionNormalized);

            // Đặt lại timer sau khi bắn
            _timer = 0; 
        }
    }
    public void ModifyHealth(float delta)
    {
        _currentHealth += delta;
        if (_currentHealth < 0) GameOver();
    }
    private void GameOver()
    {
        Debug.Log("Game Over");
        _isEnable = false;
        Destroy(gameObject);
    }

    private void Win()
    {
        Debug.Log("You Win");
        _enemiesCleared = true;
        RoomManager.Instance.CheckSwitchRoom();
    }
}
