using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour, IRemovable
{
    [SerializeField] private Transform _container;
    [SerializeField] private T _prefab;

    private Queue<T> _pool;

    public event UnityAction<T> ObjectSpawned; 

    private void Awake()
    {
        _pool = new Queue<T>();
    }
    
    public T GetObject()
    {
        T removable;
        
        if (_pool.Count > 0)
            removable = _pool.Dequeue();
        else
            removable = Instantiate(_prefab, _container);

        ObjectSpawned?.Invoke(removable);
        
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
