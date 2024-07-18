using UnityEngine;

public class EnemyRemover : ObjectRemover<Enemy>
{
    private void OnEnable()
    {
        Pool.ObjectSpawned += ListenEnemy;
    }

    private void OnDisable()
    {
        Pool.ObjectSpawned -= ListenEnemy;
    }

    private void ListenEnemy(Enemy enemy)
    {
        enemy.Died += PutEnemyInPool;
        enemy.Disabled += StopListening;
    }

    private void PutEnemyInPool(Enemy enemy)
    {
        enemy.Died -= PutEnemyInPool;
        Pool.PutObject(enemy);
    }

    private void StopListening(Enemy enemy)
    {
        enemy.Died -= PutEnemyInPool;
        enemy.Disabled -= StopListening;
    }
}
