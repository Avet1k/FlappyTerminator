using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool _pool;

    private void Start()
    {
        StartCoroutine(GeneratingEnemies());
    }

    private IEnumerator GeneratingEnemies()
    {
        var delay = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();

            yield return delay;
        }
    }

    private void Spawn()
    {
        float positionY = Random.Range(_lowerBound, _upperBound);
        Vector3 point = new Vector3(transform.position.x, positionY, transform.position.z);

        var enemy = _pool.GetObject();
        enemy.gameObject.SetActive(true);
        enemy.transform.position = point;
    }
}
