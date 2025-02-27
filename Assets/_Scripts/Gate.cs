using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private SpriteRenderer gateRenderer;
    [SerializeField] private BoxCollider2D boxCollider;

    private void Update()
    {
        // Chuyển gate thành màu xám nếu chưa thể chuyển room
        if (RoomManager.Instance.CanSwitchRoom)
        {
            gateRenderer.color = Color.white;
        }
        else
        {
            gateRenderer.color = Color.gray;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && RoomManager.Instance.CanSwitchRoom)
        {
            RoomManager.Instance.SwitchRoom();
        }
    }
}
