using System;
using System.Collections;
using UnityEngine;

public class EnemyAttacker : Attacker
{
    [SerializeField] private float _attackDelay;

    private Vector3 _offset = new(-1, 0, 0);
    
    public void SetPool(BulletPool pool)
    {
        BulletPool = pool;
    }

    private void Start()
    {
        StartCoroutine(nameof(Shooting));
    }

    private IEnumerator Shooting()
    {
        var delay = new WaitForSeconds(_attackDelay);

        while (enabled)
        {
            yield return delay;

            Shoot();
        }
    }

    protected override void Shoot()
    {
        var bullet = BulletPool.GetObject();
        Vector3 direction = new(Mathf.Cos(transform.rotation.z), Mathf.Sin(transform.rotation.z), 0);

        bullet.transform.position = transform.position + _offset;
        bullet.transform.rotation = transform.rotation;
        bullet.SetColor(BulletColor);
        bullet.SetSpeed(BulletSpeed);
        bullet.SetDirection(direction);
        bullet.gameObject.SetActive(true);
    }
}
