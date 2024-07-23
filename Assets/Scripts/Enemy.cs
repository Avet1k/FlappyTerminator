using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyAttacker))]
public class Enemy : MonoBehaviour, IInteractable, IRemovable, IHittable
{
    private EnemyAttacker _attacker;

    public event UnityAction<Enemy> Died;

    public event UnityAction<Enemy> Disabled; 
    
    private void Awake()
    {
        _attacker = GetComponent<EnemyAttacker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bullet _))
            Died?.Invoke(this);
    }

    private void OnDisable()
    {
        Disabled?.Invoke(this);
    }

    public void SetBulletPool(BulletPool _bulletPool)
    {
        _attacker.SetPool(_bulletPool);
    }
}
