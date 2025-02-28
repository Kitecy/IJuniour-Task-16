using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool IsSpawning;

    [SerializeField] private Enemy _prefab;
    [SerializeField] private ProjectileSpawner _projectileSpawner;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Transform _spawnposition;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    private WaitForSeconds _delay;

    private void Awake()
    {
        _delay = new(_spawnDelay);

        if (IsSpawning)
            StartCoroutine(SpawnDelay());
    }

    private void Spawn()
    {
        float y = Random.Range(_minY, _maxY);
        Enemy enemy = Instantiate(_prefab, new Vector3(_spawnposition.position.x, y, 0), Quaternion.identity);
        enemy.SetProjectileSpawner(_projectileSpawner);

        if (IsSpawning)
            StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay()
    {
        yield return _delay;
        Spawn();
    }
}
