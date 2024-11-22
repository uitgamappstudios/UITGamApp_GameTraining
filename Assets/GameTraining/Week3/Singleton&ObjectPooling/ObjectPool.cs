using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<PooledObject> pool; // Có thể sử dụng Stack, Queue,... thay cho List
    [SerializeField] private int initCapacity; // Số lượng item có sẵn trong pool
    [SerializeField] private PooledObject pooledObject;

    private void Start()
    {
        InitPool();
    }

    public void InitPool()
    {
        pool = new List<PooledObject>();
        for (int i = 0; i < initCapacity; i++)
        {
            Create();
        }
    }

    // Tạo object mới và thêm vào pool
    public PooledObject Create()
    {
        PooledObject instance = Instantiate(pooledObject);
        instance.pool = this;
        instance.gameObject.SetActive(false);
        pool.Add(instance);
        return instance;
    }

    // Lấy object ra từ pool
    public PooledObject GetPooledObject()
    {
        PooledObject instance;
        if (pool.Count == 0)
        {
            instance = Create();
        }
        else
        {
            instance = pool.ElementAt(pool.Count - 1);
        }
        pool.Remove(instance);
        instance.gameObject.SetActive(true);
        return instance;
    }

    // Trả object về lại pool
    public PooledObject ReleasePooledObject(PooledObject pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        pool.Add(pooledObject);
        return pooledObject;
    }
}
