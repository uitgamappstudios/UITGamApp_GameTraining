using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<PooledObject> pool; // Có thể sử dụng Stack, Queue,... thay cho List
    [SerializeField] private int initCapacity; // Số lượng item có sẵn trong pool

    private void Start()
    {
        InitPool();
    }

    public void InitPool()
    {
        pool = new List<PooledObject>();
    }

    // Tạo object mới và thêm vào pool
    public PooledObject Create(PooledObject pooledObject)
    {
        PooledObject instance = Instantiate(pooledObject);
        instance.pool = this;
        instance.name = pooledObject.name;
        instance.gameObject.SetActive(false);
        pool.Add(instance);
        return instance;
    }

    // Lấy object ra từ pool
    public PooledObject GetPooledObject(PooledObject pooledObject)
    {
        PooledObject instance;
        instance = pool.Find(o => o.name == pooledObject.name);
//        Debug.Log(instance);
        if (!instance)
        {
            instance = Create(pooledObject);
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
