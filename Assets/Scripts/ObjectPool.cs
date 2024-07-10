using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour, IRemovable
{
    [SerializeField] private Transform _container;
    [SerializeField] private T _prefab;

    private Queue<T> _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
    }
    
    public T GetObject()
    {
        if (_pool.Count > 0)
            return _pool.Dequeue();

        var removable = Instantiate(_prefab, _container);

        return removable;
    }

    public void PutObject(T removable)
    {
        _pool.Enqueue(removable);
        removable.gameObject.SetActive(false);
    }
    
    public void Reset()
    {
        _pool.Clear();
    }
}
