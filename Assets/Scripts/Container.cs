using UnityEngine;

public class Container<T> : MonoBehaviour where T : MonoBehaviour, IRemovable
{
    [SerializeField] private ObjectPool<T> _pool;

    public void PutActiveObjectsInPool()
    {
        T[] activeObjects = GetComponentsInChildren<T>(includeInactive: false);
        
        foreach (T obj in activeObjects)
            _pool.PutObject(obj);
    }
}
