using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private BulletPool _pool;

    private KeyCode _shootKey = KeyCode.S;

    private void Update()
    {
        if (Input.GetKeyDown(_shootKey))
        {
            
        }
    }
}
