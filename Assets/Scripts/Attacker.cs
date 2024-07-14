using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Attacker : MonoBehaviour
{
    [SerializeField] protected BulletPool BulletPool;
    [SerializeField] protected Color BulletColor;
    [SerializeField] protected float BulletSpeed;

    protected abstract void Shoot();
}
