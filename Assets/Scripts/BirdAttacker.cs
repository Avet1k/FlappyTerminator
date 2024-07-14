using UnityEngine;

public class BirdAttacker : Attacker
{
    private KeyCode _shootKey = KeyCode.S;

    private void Update()
    {
        if (Input.GetKeyDown(_shootKey))
        {
            Shoot();
        }
    }
}
