using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour, IRemovable
{
    private float _speed;
    private SpriteRenderer _renderer;
    private Vector3 _direction;
    
    public event UnityAction<Bullet> HitEnemy;

    public event UnityAction<Bullet> Disabled;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position += _direction * (_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            HitEnemy?.Invoke(this);
        }
    }

    private void OnDisable()
    {
        Disabled?.Invoke(this);
    }

    public void SetColor(Color color)
    {
        _renderer.color = color;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
