## Design Patterns trong Unity
### Tổng quan Design Patterns
> **Design patterns** là các giải pháp tổng quát được đưa ra nhằm giải quyết các vấn đề phần mềm phổ biến, gặp phải hàng ngày. Mỗi một design pattern đều được tối ưu và sử dụng cho một vấn đề phần mềm cụ thể.

Khái niệm Design Patterns được khởi xướng lần đầu trong cuốn sách *Design Patterns: 
Elements of Reusable Object-Oriented Software* được viết bởi bốn lập trình viên Erich Gamma, Richard Helm, Ralph 
Johnson, John Vlissides. Cuốn sách mô tả 23 design patterns được sử dụng để giải quyết các vấn đề phần mềm thường gặp. Vì những cống hiến to lớn của mình, bốn lập trình viên còn thường được người đời gọi là **"The Gang of Four"**

Như đã viết ở trên, các design patterns về bản chất chỉ là giải pháp tổng quát nên việc hai hoặc nhiều người cùng sử dụng một design pattern cũng có thể có cách tổ chức code khác nhau. Hãy tưởng tượng mỗi một design pattern là một bản vẽ thiết kế tổng quát và tùy theo mỗi cá nhân sẽ có một cách xây dựng khác nhau dựa trên cơ sở của bản thiết kế ban đầu.

### Công dụng Design Patterns
- **Tăng tốc độ phát triển phần mềm:** Việc trang bị cho bản thân kiến thức về các design patterns sẽ giúp cho lập trình viên giải quyết các vấn đề thường gặp trên một cách nhanh chóng mà không cần phải suy nghĩ ra giải pháp của riêng mình. Từ đó giúp tốc độ phát triển phần mềm được tăng lên đáng kể.

- **Clean code:** Các design pattern nếu được tích hợp một cách hiệu quả không chỉ giúp cho các thành viên khác trong team dễ dàng theo dõi, hình dung cách hoạt động hơn mà còn giúp cho hệ thống trở nên linh hoạt, dễ dàng bảo trì và nâng cấp về sau.

- **Tăng hiệu suất (performance) của hệ thống:** Một vài design pattern có khả năng tối ưu, giúp hệ thống hoạt động trơn tru hơn.

### Các Design Patterns có sẵn trong Unity
Trong Unity, một số design patterns đã được cài đặt sẵn cho người dùng. Các design patterns bao gồm:
- **Game Loop:** Các hàm [`Update()`](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html), [`FixedUpdate()`](https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html), [`LateUpdate()`](https://docs.unity3d.com/ScriptReference/MonoBehaviour.LateUpdate.html) trong class MonoBehaviour
- **Prototype:** Tính năng [`Prefab`](https://docs.unity3d.com/Manual/Prefabs.html) trong Unity
- **Component:** Tính năng [`Component`](https://docs.unity3d.com/ScriptReference/Component.html) trong Unity

## Singleton và Object Pooling
### 1. Singleton
**Định nghĩa**

Theo The Gang of Four, một class được gọi là singleton nếu đảm bảo hai điều sau:
- Chỉ có một thể hiện (instance) được tạo ra cho mỗi singleton class.
- Thể hiện của singleton class có thể được truy cập với global scope (truy cập từ mọi class khác trong project).

**Ví dụ**

Dưới đây là một ví dụ về class BulletManager. Đây là một singleton class dùng để quản lý bullet trong game.
```csharp
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
```

Các class khác trong project có thể sử dụng singeton BulletManager một cách dễ dàng bằng cách reference đến instance của class:
```csharp
BulletManager.Instance
```

Lúc này, ta có thể gọi các thuộc tính và phương thức public của singleton BulletManager. Dưới đây là đoạn code ví dụ:
```csharp
using UnityEngine;

public class BounceBullet : BaseBullet
{
    private Vector2 prevVel;
    private float elapsedTime;
    [SerializeField] private float existTime;

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {
        elapsedTime = 0;
    }

    public override void BulletInit(Vector2 spawnPosition, Vector2 shootDirection)
    {
        base.BulletInit(spawnPosition, shootDirection);
    }

    private void Update()
    {
        // Lưu lại vận tốc của đạn nhằm sử dụng cho frame sau
        prevVel = rb.velocity;
        Move(rb.velocity);

        elapsedTime += Time.deltaTime;
        if (elapsedTime > existTime)
        {
            BulletManager.Instance.ReleaseBullet(this);
        }
    }
    override public void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        rb.velocity = Vector2.Reflect(prevVel.normalized, collision.contacts[0].normal) * speed;
    }
}
```

**Ưu điểm**
- **Thân thiện với người mới:** Đối với những người mới tiếp xúc lần đầu với design pattern thì Singleton là một trong những design pattern đầu tiên được học do tính dễ tiếp cận và độ tiện lợi của nó.
- **Tăng tốc độ xử lý của hệ thống:** Vì một singleton class có thể được truy cập ở tất cả các class trong project, ta có thể sử dụng class trực tiếp mà không cần phải sử dụng hàm [`GetComponent()`](https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html) hoặc các hàm `Find` có tốc độ chậm hơn

**Nhược điểm**
- **Dễ dẫn đến tình trạng "Spaghetti code":** Độ tiện lợi của việc truy cập trực tiếp vào các singleton class đôi khi lại là con dao hai lưỡi. Việc lạm dụng tính chất này của singleton có thể dẫn đến nhiều class/component bị phụ thuộc. Điều này sẽ dẫn đến kiến trúc code dễ bị rối (Spaghetti code) về sau này gây khó khăn cho việc bảo trì, nâng cấp.
- **Khuyến khích việc phụ thuộc giữa các class/component với nhau:** Hầu hết các design pattern được sử dụng nhằm hạn chế sự phụ thuộc vào nhau giữa các class, từ đó giúp cho việc bảo trì, nâng cấp, testing trở nên dễ dàng hơn. Nhưng trong trường hợp của Singleton thì ngược lại hoàn toàn, việc thay đổi cách hoạt động của singleton có thể ảnh hưởng đến các class sử dụng nó. Đây là lý do mà Singleton còn hay được coi là một "Anti Pattern"



### 2. Object Pooling
**Định nghĩa**


**Ví dụ**

**Ưu điểm**

**Nhược điểm**

## Tài liệu đọc thêm
## Nguồn tham khảo
