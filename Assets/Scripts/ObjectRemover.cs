using UnityEngine;

public abstract class ObjectRemover<T> : MonoBehaviour where T : MonoBehaviour, IRemovable
{
    [SerializeField] protected ObjectPool<T> Pool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out T removable))
            Pool.PutObject(removable);
    }
}
