using UnityEngine;

public class BulletRemover : ObjectRemover<Bullet>
{
    private void OnEnable()
    {
        Pool.ObjectSpawned += ListenBullet;
    }

    private void OnDisable()
    {
        Pool.ObjectSpawned -= ListenBullet;
    }

    private void ListenBullet(Bullet bullet)
    {
        bullet.Hit += PutBulletInPool;
        bullet.Disabled += StopListening;
    }

    private void PutBulletInPool(Bullet bullet)
    {
        bullet.Hit -= PutBulletInPool;
        Pool.PutObject(bullet);
    }

    private void StopListening(Bullet bullet)
    {
        bullet.Hit -= PutBulletInPool;
        bullet.Disabled -= StopListening;
    }
}
