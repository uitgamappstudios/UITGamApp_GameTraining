using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBirdComponent : MonoBehaviour
{
    [Header("Key Settings")]
    [Tooltip("Lấy Component và thay đổi trọng lực")]
    [SerializeField] private KeyCode GravitySwitch = KeyCode.Alpha1;
    [Tooltip("Thêm Component AudioSource")]
    [SerializeField] private KeyCode AddAudioSource = KeyCode.Alpha2;
    [Tooltip("Gỡ Component AudioSource")]
    [SerializeField] private KeyCode RemoveAudioSource = KeyCode.Alpha3;
    [Tooltip("Bật/tắt Component AngryBirdMovement")]
    [SerializeField] private KeyCode MovementSwitch = KeyCode.Alpha4;

    // Update is called once per frame
    void Update()
    {

        // Nhấn phím 1 để lấy Component Rigidbody2D từ GameObject và thay đổi trọng lực tác dụng lên Angry Bird
        if (Input.GetKeyDown(GravitySwitch))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = -rb.gravityScale; // Thay đổi tác dụng của trọng lực từ 1 thành -1 và ngược lại
                Debug.Log("Đã thay đổi trọng lực Rigidbody thành " + rb.gravityScale);
            }
        }

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

        // Nhấn phím 3 để gỡ Component AudioSource khỏi GameObject
        if (Input.GetKeyDown(RemoveAudioSource))
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

        // Nhấn phím 4 để bật/tắt Component di chuyển
        if (Input.GetKeyDown(MovementSwitch))
        {
            if (TryGetComponent<AngryBirdMovement>(out AngryBirdMovement movement))
            {
                movement.enabled = !movement.enabled;
                if (movement.enabled)
                {
                    Debug.Log("Đã kích hoạt khả năng di chuyển của Angry Bird");
                }
                else
                {
                    Debug.Log("Đã vô hiệu khả năng di chuyển của Angry Bird");
                }
            }
        }
    }
}
