using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour, IRemovable
{
    [SerializeField] private float _speed;
    
    private SpriteRenderer _renderer;
    
    public event UnityAction HitEnemy;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, 
            _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            HitEnemy?.Invoke();
    }

    public void SetColor(Color color)
    {
        _renderer.color = color;
    }
}
