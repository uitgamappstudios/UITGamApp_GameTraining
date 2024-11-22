using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [HideInInspector] public ObjectPool bulletPool;

    private static BulletManager _instance;

    // Public property Instance sẽ reference đến _instance --> đảm bảo tính chất encapsulation
    public static BulletManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Kiểm tra có Object nào có Component BulletManager không, nếu có thì gán cho _instance
                _instance = FindObjectOfType<BulletManager>();

                // Nếu chưa có bất cứ Object nào trên scene có gán Component BulletManager, tiến hành tạo Object mới trên scene và gắn
                // Component BulletManager cho Object đó, đồng thời cho _instance reference đến Component BulletManager
                if (_instance != null)
                {
                    GameObject newGameObject = new GameObject();
                    newGameObject.name = "BulletManager";
                    _instance = newGameObject.AddComponent<BulletManager>();
                }
            }
            return _instance;
        }
        private set { }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject); // Giữ cho Object không bị Destroy khi load scene
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    private void Start()
    {
        bulletPool = GetComponent<ObjectPool>();
    }

    public bool ReleaseBullet(BaseBullet bullet)
    {
        if (bullet.TryGetComponent<PooledObject>(out PooledObject pooledObject))
        {
            BulletManager.Instance.bulletPool.ReleasePooledObject(pooledObject);
            return true;
        }
        return false;
    }

    public void Shoot(Vector2 spawnPosition, Vector2 shootDirection)
    {
        PooledObject pooledObject = bulletPool.GetPooledObject();
        
        if (pooledObject.TryGetComponent<BaseBullet>(out BaseBullet bullet))
        {
            bullet.BulletInit(spawnPosition, shootDirection);
        }
    }
}
