using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover), typeof(BirdCollisionHandler), typeof(ScoreCounter)),
 RequireComponent(typeof(BirdAttacker))]
public class Bird : MonoBehaviour
{
    private BirdCollisionHandler _collisionHandler;
    private BirdMover _mover;
    private ScoreCounter _scoreCounter;
    private BirdAttacker _attacker;

    public event UnityAction GameOver;

    private void Awake()
    {
        _collisionHandler = GetComponent<BirdCollisionHandler>();
        _mover = GetComponent<BirdMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _attacker = GetComponent<BirdAttacker>();
    }

    private void OnEnable()
    {
        _collisionHandler.Triggered += ProcessCollision;
        _attacker.BulletShot += ListenBullet;
    }
    
    private void OnDisable()
    {
        _collisionHandler.Triggered -= ProcessCollision;
        _attacker.BulletShot -= ListenBullet;
    }

    public void Reset()
    {
        _mover.Reset();
        _scoreCounter.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Ground or Enemy or Bullet)
            GameOver?.Invoke();
    }
    
    private void ListenBullet(Bullet bullet)
    {
        bullet.HitEnemy += AddScore;
        bullet.Disabled += StopListenBullet;
    }

    private void StopListenBullet(Bullet bullet)
    {
        bullet.HitEnemy -= AddScore;
        bullet.Disabled -= StopListenBullet;
    }

    private void AddScore(Bullet bullet)
    {
        _scoreCounter.Add();
    }
}