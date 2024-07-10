using System;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour, IRemovable
{
    [SerializeField] private float _speed;

    public event UnityAction HitEnemy;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            HitEnemy?.Invoke();
    }

    public void SetColor(Color color)
    {
        _renderer.material.color = color;
    }
}
