using UnityEngine;

public class ObjectRemover<T> : MonoBehaviour where T : MonoBehaviour, IRemovable
{
    [SerializeField] private ObjectPool<T> _pool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out T removable))
            _pool.PutObject(removable);
    }
}
