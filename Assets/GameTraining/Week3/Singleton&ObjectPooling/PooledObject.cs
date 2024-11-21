using System.Threading.Tasks;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    [HideInInspector] public ObjectPool pool;

    public async void BulletInit()
    {
        // Đạn khi vừa được lấy từ pool sẽ ở vị trí (0, 0, 0) và sẽ được thu vào pool sau 3s
        transform.position = Vector3.zero;
        await Task.Delay(3000);
        pool.ReleasePooledObject(this);
    }
}
