using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Attacker : MonoBehaviour
{
    [SerializeField] protected BulletPool BulletPool;
    [SerializeField] protected Color BulletColor;
    [SerializeField] protected float BulletSpeed;

    protected void Shoot()
    {
        var bullet = BulletPool.GetObject();
        Vector3 direction = transform.right;

        bullet.transform.position = transform.position + transform.right;
        bullet.transform.rotation = transform.rotation;
        bullet.SetColor(BulletColor);
        bullet.SetSpeed(BulletSpeed);
        bullet.SetDirection(direction);
        bullet.gameObject.SetActive(true);
    }
}
