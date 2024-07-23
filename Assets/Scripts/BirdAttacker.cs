using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BirdAttacker : Attacker
{
    [SerializeField] private float _shootCooldown;
    
    private KeyCode _shootKey = KeyCode.S;
    private bool _canShoot = true;

    public event UnityAction<Bullet> BulletShot;

    private void Update()
    {
        if (Input.GetKeyDown(_shootKey) && _canShoot)
        {
            var bullet = Shoot();
            _canShoot = false;
            
            StartCoroutine(nameof(CooldownCounting));
            
            BulletShot?.Invoke(bullet);
        }
    }

    private IEnumerator CooldownCounting()
    {
        var delay = new WaitForSeconds(_shootCooldown);

        yield return delay;

        _canShoot = true;
    }
}
