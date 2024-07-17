using UnityEngine;
using UnityEngine.Events;

public class BirdAttacker : Attacker
{
    private KeyCode _shootKey = KeyCode.S;

    public event UnityAction<Bullet> BulletShot;

    private void Update()
    {
        if (Input.GetKeyDown(_shootKey))
        {
            var bullet = Shoot();
            
            BulletShot?.Invoke(bullet);
        }
    }
}
