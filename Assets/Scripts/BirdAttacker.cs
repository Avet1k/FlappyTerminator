using UnityEngine;

public class BirdAttacker : Attacker
{
    [SerializeField] private float _bulletSpeed;
    
    private KeyCode _shootKey = KeyCode.S;
    private Vector3 _offset = new (1, 0, 0);

    private void Update()
    {
        if (Input.GetKeyDown(_shootKey))
        {
            var bullet = BulletPool.GetObject();
            bullet.transform.position = transform.position + _offset;
            bullet.transform.rotation = transform.rotation;
            bullet.SetColor(BulletColor);
            bullet.gameObject.SetActive(true);
        }
    }
}
