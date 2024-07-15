using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover), typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour
{
    private BirdCollisionHandler _collisionHandler;
    private BirdMover _birdMover;

    public event UnityAction GameOver;

    private void Awake()
    {
        _collisionHandler = GetComponent<BirdCollisionHandler>();
        _birdMover = GetComponent<BirdMover>();
    }

    private void OnEnable()
    {
        _collisionHandler.Triggered += ProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.Triggered -= ProcessCollision;
    }

    public void Reset()
    {
        _birdMover.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Ground or Enemy)
            GameOver?.Invoke();
    }
}