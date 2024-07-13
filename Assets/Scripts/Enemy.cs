using UnityEngine;

[RequireComponent(typeof(EnemyAttacker))]
public class Enemy : MonoBehaviour, IInteractable, IRemovable
{
    private EnemyAttacker _attacker;

    private void Awake()
    {
        _attacker = GetComponent<EnemyAttacker>();
    }

    public void SetBulletPool(BulletPool _bulletPool)
    {
        _attacker.SetPool(_bulletPool);
    }
}
