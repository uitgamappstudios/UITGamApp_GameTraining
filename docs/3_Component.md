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

<div style="text-align: center;">
  <img src="https://github.com/user-attachments/assets/d9d7844f-fb55-4955-ae37-595ddc4f119b" alt="GameObject Example" style="width: 50%;"/>
  <p><em>Hình minh họa: Mọi thứ trong game đều là GameObject</em></p>
</div>

Mặt khác, nếu game của bạn chỉ có mỗi GameObject, thì nó chỉ đơn giản là một bức ảnh tĩnh với vài ba cục pixel mà thôi! Bản thân GameObject chỉ là một cái vỏ rỗng, và đó là lý do chúng ta cần **Component**.

### Component
Nếu GameObject là một cái vỏ rỗng, thì Component chính là những mảnh ghép tạo nên chức năng của GameObject. Component bổ sung các thuộc tính và hành vi cho GameObject, giúp chúng tương tác được với thế giới trong game.

**Công thức Component**: Component = Thuộc tính + Hành vi
- Thuộc tính: Các giá trị như vị trí, kích thước, trọng lực, màu sắc...
- Hành vi: Các hành động, như di chuyển, va chạm, hoặc phát âm thanh...
Một GameObject có thể chứa nhiều Component. Mỗi Component phụ trách một chức năng cụ thể: Tương tự như giáp trụ dùng để phòng thủ, kiếm để tấn công, thú cưỡi để tăng tốc độ di chuyển vậy!

<div style="text-align: center;">
  <img src="https://github.com/user-attachments/assets/17877fc6-eb82-4113-afc0-7211d2fdb90f" alt="Component Example" style="width: 50%;"/>
  <p><em>Hình minh họa: Một số component cơ bản trong nhân vật Angry Bird</em></p>
</div>

Và một điều tuyệt vời hơn là bạn hoàn toàn có thể chỉnh sửa Component theo ý mình, hoặc tạo ra những Component mới để gắn vào GameObject! Việc vận dụng nhuần nhuyễn hai anh bạn này là mấu chốt để tạo ra một con game cơ bản!

## Sử dụng Component
### Phân loại Component
### Thêm Component
#### Thêm Component cơ bản
#### Thêm Script Component
#### Gỡ Component

### Chỉnh sửa Component
#### Chỉnh sửa trên Unity Editor
#### Chỉnh sửa bằng Script

### Deactivate Component

## Một số loại Component có sẵn trong Unity
### Transform
### Rigidbody
### Collider
### Sprite Renderer
### Camera
### AudioSource

## Hướng dẫn chạy code

## Tóm lược
### Component là gì?
### Tại sao lại cần sử dụng Component?
## Nguồn tham khảo
- [Unity Documentation](https://docs.unity3d.com/2022.3/Documentation/Manual/)
