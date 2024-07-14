using UnityEngine;

public class BirdAttacker : Attacker
{
    private KeyCode _shootKey = KeyCode.S;
    private Vector3 _offset = new (1, 0, 0);

    private void Update()
    {
        if (Input.GetKeyDown(_shootKey))
        {
            Shoot();
        }
    }

    protected override void Shoot()
    {
        var bullet = BulletPool.GetObject();
        Vector3 direction = new (Mathf.Cos(transform.rotation.z), Mathf.Sin(transform.rotation.z));
        
        bullet.transform.position = transform.position + _offset;
        bullet.transform.rotation = transform.rotation;
        bullet.SetColor(BulletColor);
        bullet.SetSpeed(BulletSpeed);
        bullet.SetDirection(direction);
        bullet.gameObject.SetActive(true);
    }
}
