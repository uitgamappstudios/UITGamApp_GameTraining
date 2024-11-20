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
### Thêm Component
#### 1. Thêm Component cơ bản
#### 2. Thêm Script Component
#### 3. Gỡ Component

### Chỉnh sửa Component
#### 1. Chỉnh sửa trên Unity Editor
#### 2. Chỉnh sửa bằng Script

### Deactivate Component

## Một số loại Component có sẵn trong Unity
### 1. Transform
### 2. Rigidbody
### 3. Collider
### 4. Sprite Renderer
### 5. Camera
### 6. AudioSource

## Hướng dẫn chạy code minh họa

## Tóm lược
### Component là gì?
### Tại sao lại cần sử dụng Component?
## Nguồn tham khảo
- [Unity Documentation](https://docs.unity3d.com/2022.3/Documentation/Manual/)
