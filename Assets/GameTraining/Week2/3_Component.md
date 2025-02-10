## Tổng quan về GameObject và Component
Để hiểu được khái niệm về **Component**, chúng ta sẽ xem xét khái niệm này cùng với một concept cũng rất quan trọng trong Unity: **GameObject**.

Tưởng tượng bản thân bạn đang chơi Minecraft. Để tăng chiến lực, bạn sẽ "lên đồ" cho nhân vật của mình: Đổi liềm thành kiếm, thêm nón, giáp... 
và bạn có thể đánh gục zombie một cách ngon ơ, phá cục quặng trong một nốt nhạc. Tháo hết đồ ra thì bạn chỉ là một cục pixel chiến lực bằng 0.

Tương tự vậy, Unity **GameObject** cũng giống như cục pixel chiến lực bằng 0, còn **Component** chính là combo kiếm, nón, giáp, thú cưng, vật cưỡi... 
giúp cục pixel này có thể xưng bá thiên hạ, trở thành một thành phần hoàn chỉnh trong con game sắp ra lò của bạn!

### GameObject
> **Mọi đối tượng trong trò chơi của bạn đều là một GameObject**, từ nhân vật và vật phẩm thu thập được đến ánh sáng, camera và hiệu ứng đặc biệt.
> Tuy nhiên, **một GameObject không thể tự mình làm bất cứ điều gì**; bạn cần cung cấp thuộc tính cho nó trước khi nó có thể trở thành một nhân vật, môi trường hoặc hiệu ứng đặc biệt.

Nói một cách đơn giản, trong game của bạn có cái gì thì cái đó chắc chắn là một GameObject. Đến cả background cũng là một GameObject.

<p align="center">
  <img src="https://github.com/user-attachments/assets/d9d7844f-fb55-4955-ae37-595ddc4f119b" alt="GameObject Example" style="width: 50%;"/>
  <p align="center"><em>Hình minh họa: Mọi thứ trong game đều là GameObject</em></p>
</p>

Mặt khác, nếu game của bạn chỉ có mỗi GameObject, thì nó chỉ đơn giản là một bức ảnh tĩnh với vài ba cục pixel mà thôi! Bản thân GameObject chỉ là một cái vỏ rỗng, và đó là lý do chúng ta cần **Component**.

### Component
Nếu GameObject là một cái vỏ rỗng, thì Component chính là những mảnh ghép tạo nên chức năng của GameObject. Component bổ sung các thuộc tính và hành vi cho GameObject, giúp chúng tương tác được với thế giới trong game.

**Công thức Component**: Component = Thuộc tính + Hành vi
- Thuộc tính: Các giá trị như vị trí, kích thước, trọng lực, màu sắc...
- Hành vi: Các hành động, như di chuyển, va chạm, hoặc phát âm thanh...

Chẳng hạn, đối với Component *AudioSource* dùng để quản lý âm thanh:
- Thuộc tính:
  - `clip`: File âm thanh cần phát.
  - `volume`: Điều chỉnh âm lượng.
- Hành vi:
  - Phát (`Play()`), dừng (`Stop()`).

Một GameObject có thể chứa nhiều Component. Mỗi Component phụ trách một chức năng cụ thể: Tương tự như giáp trụ dùng để phòng thủ, kiếm để tấn công, thú cưỡi để tăng tốc độ di chuyển vậy! Bạn sẽ chỉnh sửa các thuộc tính của Component và kích hoạt các hành vi của Component để GameObject hành động theo đúng ý bạn muốn.

<p align="center">
  <img src="https://github.com/user-attachments/assets/17877fc6-eb82-4113-afc0-7211d2fdb90f" alt="Component Example" style="width: 50%;"/>
  <p align="center"><em>Hình minh họa: Một số component cơ bản trong nhân vật Angry Bird</em></p>
</p>

Và một điều tuyệt vời hơn là bạn hoàn toàn có thể tạo ra những Component mới để gắn vào GameObject. Việc vận dụng nhuần nhuyễn hai thành tố này là mấu chốt để tạo ra một game cơ bản!

## Phân loại Component
### 1. Component có sẵn (Built-in Components) 

Đây là những Component đã được Unity định nghĩa sẵn, có sẵn trong Unity Editor để bạn có thể dễ dàng sử dụng. Các Component này bao gồm những tính năng cơ bản để xây dựng game như vật lý, hình ảnh, âm thanh, va chạm, v.v.

Bạn có thể tham khảo một số Component có sẵn ở phần sau: [Một số loại Component có sẵn trong Unity](#một-số-loại-component-có-sẵn-trong-unity).

### 2. Component tự định nghĩa (Script Components)

Đây là những Component mà bạn tự tạo ra bằng cách viết mã C# để thêm các tính năng hoặc hành vi tùy chỉnh cho GameObject. Những Component này thường dùng để kiểm soát hành vi của GameObject thông qua lập trình. Chẳng hạn, bạn có thể tạo ra các component cho hành vi di chuyển của nhân vật, điều khiển AI, hoặc các logic đặc biệt khác.

**Ví dụ:** Component này sẽ làm cho GameObject (nhân vật) di chuyển dựa trên input của người chơi.
```csharp
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    void Update()
    {
        // Khởi tạo giá trị di chuyển
        float horizontal = 0f;
        float vertical = 0f;

        // Kiểm tra các phím bấm và thay đổi giá trị di chuyển tương ứng
        if (Input.GetKey(KeyCode.A)) // Phím A (di chuyển sang trái)
        {
            horizontal = -1f;
        }
        if (Input.GetKey(KeyCode.D)) // Phím D (di chuyển sang phải)
        {
            horizontal = 1f;
        }
        if (Input.GetKey(KeyCode.W)) // Phím W (di chuyển lên trên)
        {
            vertical = 1f;
        }
        if (Input.GetKey(KeyCode.S)) // Phím S (di chuyển xuống dưới)
        {
            vertical = -1f;
        }
        
        // Tính toán hướng di chuyển và áp dụng nó
        Vector3 move = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(move);
    }
}
```

### 3. Sự khác biệt giữa Component có sẵn và Component tự định nghĩa

| **Đặc điểm**               | **Component có sẵn**                           | **Component tự định nghĩa**                  |
|--------------------------|------------------------------------------------|---------------------------------------------|
| **Tạo ra bởi**            | Unity cung cấp sẵn                            | Lập trình viên tự tạo ra                    |
| **Ví dụ**                 | `Rigidbody`, `Collider`, `Camera`, `SpriteRenderer` | Các script như `PlayerMovement`, `AIController`, v.v. |
| **Cấu hình**              | Cấu hình trực tiếp qua Unity Editor            | Cấu hình thông qua mã nguồn C#              |
| **Mục đích**              | Cung cấp các tính năng cơ bản của Unity        | Thực hiện hành vi hoặc tính năng đặc biệt cho GameObject |

## Sử dụng Component
Vậy làm sao để "lên đồ" cho Angry Bird của bạn? Có 3 thao tác cơ bản để giúp Angry Bird "luyện công": Thêm trang bị, sửa trang bị, gỡ trang bị, ẩn trang bị.

### 1. Thao tác với component trên Unity Editor

#### 1.1. Thêm Component có sẵn trong Unity Editor
1. **Chọn GameObject** mà bạn muốn thêm component.
2. **Mở cửa sổ Inspector** (nếu chưa có, vào **Window → General → Inspector**).
3. Nhấn vào nút **Add Component** ở cuối cửa sổ **Inspector**.
4. Tìm kiếm và chọn **Component** bạn muốn thêm (ví dụ: **Rigidbody, Collider, AudioSource**...).
5. Component sẽ được thêm vào GameObject ngay lập tức.

**Ví dụ:** Nếu bạn muốn thêm **Rigidbody 2D** để Angry Bird chịu tác động vật lý (biết rơi từ trên trời xuống):
- Chọn **GameObject** mà bạn muốn thêm component, ở đây là Angry Bird.
- Nhấn **Add Component → Rigidbody**.
- Angry Bird của bạn đã biết rơi tự do rồi đó!

<p align="center">
  <img src="https://github.com/user-attachments/assets/515068b6-0a85-4ebc-9cce-b47726eb34b2" alt="Add Component Example" style="width: 80%;"/>
  <p align="center"><em>Hình minh họa: Thêm component vào GameObject</em></p>
</p>

#### 1.2. Chỉnh sửa Component
- Mở **Inspector**.
- Chỉnh sửa các giá trị của Component (ví dụ: thay đổi trọng lượng của **Rigidbody**, bật/tắt **Collider**).

**Ví dụ:** Bây giờ bạn không muốn Angry Bird rơi tự do nữa, bạn muốn Angry Bird lơ lửng như siêu nhân:
- Bạn sẽ chỉnh sửa component **Rigidbody 2D** trong số những component của Angry Bird
- Tìm chỉ số **Gravity Scale**, đổi thành giá trị 0.
- Angry Bird của bạn không rơi nữa, Angry Bird của bạn lơ lửng.

<p align="center">
  <img src="https://github.com/user-attachments/assets/58996add-1d9d-4fff-adad-3bb041bdefa2" alt="Edit Component Example" style="width: 80%;"/>
  <p align="center"><em>Hình minh họa: Chỉnh sửa chỉ số component trên Unity Editor</em></p>
</p>

#### 1.3. Gỡ Component
Nếu bạn lỡ bắt cái loa cho Angry Bird bằng component AudioSource, nhưng bạn phát hiện Angry Bird quá ồn ào và muốn ẻm nín? Bạn cũng có thể gỡ **Component** nếu không cần sử dụng nữa bằng vài thao tác đơn giản.
1. Chọn **GameObject** trong **Hierarchy**.
2. Trong **Inspector**, tìm Component muốn xóa.
3. Nhấn vào dấu ba chấm **(⋮)** ở góc phải của Component.
4. Chọn **Remove Component**.

<p align="center">
  <img src="https://github.com/user-attachments/assets/fbffa129-76df-4e9c-8496-b5092ae8859b" alt="Remove Component Example" style="width: 80%;"/>
  <p align="center"><em>Hình minh họa: Xóa component trên Unity Editor</em></p>
</p>

#### 1.4. Vô hiệu hóa (Deactivate) Component
Thay vì bắt Angry Bird nín vĩnh viễn, bạn muốn bật tắt tính năng hét của em ý vì biết đâu bạn có thể dùng. Lúc này, bạn có thể vô hiệu hóa Component để nó không hoạt động nhưng vẫn giữ lại mọi setting đang có của nó.

- Bỏ chọn **Enabled** trong **Inspector** (nếu có).

<p align="center">
  <img src="https://github.com/user-attachments/assets/93aa344e-6851-4d00-a16f-4e5a9bc62540" alt="Deactivate Component Example" style="width: 80%;"/>
  <p align="center"><em>Hình minh họa: Vô hiệu hóa component trên Unity Editor</em></p>
</p>

### 2. Thao tác với component sử dụng Script
#### 2.1. Script Component
Bây giờ bạn muốn Angry Bird có thể sở hữu những cử động phức tạp hơn. Lúc này, những component cơ bản vẫn chưa đủ xài, đây là khi bạn cần những component custom được định nghĩa qua Script!

Cách bạn thao tác với Script component giống hệt như những bước ở phần 1. Vì bản thân Script component cũng là một component bình thường. Điểm khác biệt là bạn phải tự tạo Script.

**Bước 1: Tạo Script Mới**

1. Trong **Project Window**, nhấn **Create → C# Script**.
2. Đặt tên cho script, ví dụ: `AngryBirdFall`.
3. Mở script bằng code editor.

<p align="center">
  <img src="https://github.com/user-attachments/assets/249f88d8-b146-4d32-9cbd-e426f6ef96b2" alt="Create Script Component Example" style="width: 90%;"/>
  <p align="center"><em>Hình minh họa: Tạo script AngryBirdMovement.cs</em></p>
</p>

**Bước 2: Thêm Script vào GameObject**

- **Cách 1**: Kéo thả script vào GameObject trong **Hierarchy**.
- **Cách 2**: Sử dụng **Add Component** trong **Inspector**, nhập tên script.

<p align="center">
  <img src="https://github.com/user-attachments/assets/f41275e2-8d4f-4399-85e5-17b940998164" alt="Add Script Component Example" style="width: 50%;"/>
  <p align="center"><em>Hình minh họa: Thêm script AngryBirdMovement vào GameObject AngryBird</em></p>
</p>

**Bước 3: Viết Script**
Bây giờ bạn muốn Angry Bird di chuyển theo hai hướng trái phải và lăn lông lốc trên mặt đường theo hiệu lệnh của bạn. Chúng ta cần Angry Bird có thể:
- Lắng nghe input từ bàn phím.
- Di chuyển trái phải (thuộc tính **position** trong component **Transform**).
- Lăn khi di chuyển (thuộc tính **rotation** trong component **Transform**).

**Code mẫu:**
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBirdMovement : MonoBehaviour
{

    [Header("Settings")]
    public float moveSpeed = 5f;   // Tốc độ di chuyển ngang
    public float rotationSpeed = 200f; // Tốc độ lăn

    // Hàm update sẽ được gọi liên tục khi game chạy
    private void Update()
    {
        Move();
    }

    void Move()
    {
        // Nhận input từ bàn phím (A/D hoặc phím mũi tên)
        float moveInput = Input.GetAxis("Horizontal");

        if (moveInput != 0)
        {
            // Di chuyển trái/phải (thay đổi vị trí theo trục X)
            transform.position += Vector3.right * moveInput * moveSpeed * Time.deltaTime;

            // Lăn Angry Bird theo hướng di chuyển
            transform.Rotate(Vector3.forward, -moveInput * rotationSpeed * Time.deltaTime);
        }
    }
}

```

#### 2.2. Chỉnh sửa giá trị các biến của Script trong Unity Editor
Khi bạn viết một script C# trong Unity, có thể cần chỉnh sửa giá trị biến trực tiếp trong Unity Editor mà không cần thay đổi mã nguồn. Điều này giúp dễ dàng tinh chỉnh gameplay mà không phải mở code mỗi lần muốn chỉnh.

**Cách 1:** Sử dụng `public` để hiển thị biến trong Inspector
```csharp
public class AngryBirdMovement : MonoBehaviour
{
    public float moveSpeed = 5f;   // Tốc độ di chuyển ngang
    public float rotationSpeed = 200f; // Tốc độ lăn
}
```

**Cách 2:** Sử dụng `[SerializeField]` để hiển thị biến private trong Inspector
```csharp
public class AngryBirdMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;   // Tốc độ di chuyển ngang
    [SerializeField] private float rotationSpeed = 200f; // Tốc độ lăn
}
```
Lợi ích của `[SerializeField]`:
- Biến vẫn hiển thị trong Inspector.
- Tránh bị chỉnh sửa ngoài ý muốn từ các script khác.

Bạn cũng có thể tổ chức các biến trong Inspector bằng cách thêm chú thích và giới hạn giá trị. Chẳng hạn:
```csharp
public class AngryBirdMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Tốc độ di chuyển của nhân vật")]
    [Range(1f, 10f)] 
    [SerializeField] private float moveSpeed = 5f;
    [Tooltip("Tốc độ lăn của nhân vật")]
    [Range(1f, 10f)] 
    [SerializeField] private float rotationSpeed = 200f;
}
```

Sẽ được kết quả như sau trong Inspector:
<p align="center">
  <img src="https://github.com/user-attachments/assets/d1bf284f-99bf-4c41-8d7a-2911cb725f6d" alt="Serialize Field Example" style="width: 50%;"/>
</p>

### 3. Một số lệnh thao tác với Component bằng Script
Trong Unity, bạn có thể **thêm, xóa, bật/tắt hoặc chỉnh sửa** Component bằng script. Sau đây là một số lệnh cơ bản mà bạn có thể cần sử dụng:

#### 3.1. Lấy Component từ GameObject (`GetComponent<T>()`)
Dùng **`GetComponent<T>()`** để truy cập vào một Component gắn trên **GameObject** và thay đổi các thông số của nó.

```csharp
public class AngryBirdComponent : MonoBehaviour
{
    void Update()
    {
        // Nhấn phím 1 để lấy Component Rigidbody2D từ GameObject và thay đổi trọng lực tác dụng lên Angry Bird
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = -rb.gravityScale; // Thay đổi tác dụng của trọng lực từ 1 thành -1 và ngược lại
                Debug.Log("Đã thay đổi trọng lực Rigidbody thành " + rb.gravityScale);
            }
        }
    }
}
```

Cũng có thể dùng `TryGetComponent<T>()` thay cho `GetComponent<T>()` để **tránh lỗi** khi Component không tồn tại.

```csharp
public class AngryBirdComponent : MonoBehaviour
{
    void Update()
    {
        // Nhấn phím 1 để lấy Component Rigidbody2D từ GameObject và thay đổi trọng lực tác dụng lên Angry Bird
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (TryGetComponent<Rigidbody2D>(out Rigidbody2D rb)) //Chỉ thực hiện lệnh khi component tồn tại
            {
                rb.gravityScale = -rb.gravityScale; // Thay đổi tác dụng của trọng lực từ 1 thành -1 và ngược lại
                Debug.Log("Đã thay đổi trọng lực Rigidbody thành " + rb.gravityScale);
            }
        }
    }
}
```

#### 3.2. Thêm Component mới (`AddComponent<T>()`)
Bạn có thể thêm một Component mới vào GameObject trong lúc chạy game.

```csharp
public class AngryBirdComponent : MonoBehaviour
{
    void Update()
    {
        // Nhấn phím 2 để thêm Component AudioSource vào GameObject
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (TryGetComponent<AudioSource>(out AudioSource audioCheck)) //Kiểm tra xem đã có component này chưa
            {
                Debug.Log("Đã tồn tại AudioSource");
            }
            else
            {
                AudioSource newAudio = gameObject.AddComponent<AudioSource>(); //Nếu chưa, thêm component mới vào
                Debug.Log("Đã thêm AudioSource mới");
            }
        }
    }
}
```

#### 3.3. Gỡ bỏ Component (`Destroy()`)**
Dùng `Destroy(component)` để xóa một Component khỏi GameObject.

```csharp
public class AngryBirdComponent : MonoBehaviour
{
    void Update()
    {
        // Nhấn phím 3 để gỡ Component AudioSource khỏi GameObject
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (TryGetComponent<AudioSource>(out AudioSource audioCheck)) //Kiểm tra xem có tồn tại component này không
            {
                Destroy(audioCheck);    //Nếu tồn tại, gỡ component này
                Debug.Log("Đã xóa AudioSource");
            } else
            {
                Debug.Log("Không tìm thấy AudioSource");
            }
        }
    }
}
```

#### 3.4. Bật/Tắt Component (`enabled`)
Dùng **`enabled = true/false`** để bật hoặc tắt Component mà không xóa nó.

```csharp
public class AngryBirdComponent : MonoBehaviour
{
    void Update()
    {
        // Nhấn phím 4 để bật/tắt Component di chuyển
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (TryGetComponent<AngryBirdMovement>(out AngryBirdMovement movement))
            {
                movement.enabled = !movement.enabled;
                if (movement.enabled)
                {
                    Debug.Log("Đã kích hoạt khả năng di chuyển của Angry Bird");
                } else
                {
                    Debug.Log("Đã vô hiệu khả năng di chuyển của Angry Bird");
                }
            }
        }
    }
}
```

## Một số loại Component có sẵn trong Unity
### 1. Transform
### 2. Rigidbody
### 3. Collider
### 4. Sprite Renderer
### 5. Camera
### 6. AudioSource

## Hướng dẫn lời giải bài tập về nhà
## Nguồn tham khảo
- [Unity Documentation](https://docs.unity3d.com/2022.3/Documentation/Manual/)
