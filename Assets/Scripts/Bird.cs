using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover), typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour
{
    private BirdCollisionHandler _collisionHandler;

    public event UnityAction GameOver;

    private void Awake()
    {
        _collisionHandler = GetComponent<BirdCollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.Triggered += ProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.Triggered -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Ground or Enemy)
            GameOver?.Invoke();
    }
}