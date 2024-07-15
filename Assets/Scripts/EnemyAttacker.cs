using System;
using System.Collections;
using UnityEngine;

public class EnemyAttacker : Attacker
{
    [SerializeField] private float _attackDelay;
    
    public void SetPool(BulletPool pool)
    {
        BulletPool = pool;
    }

    private void OnEnable()
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
}
