using System.Collections;
using UnityEngine;
using @Random = UnityEngine.Random;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private ProjectileSpawner _projectileSpawner;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Transform _spawnposition;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    private WaitForSeconds _delay;
    private bool _isSpawning = true;

    protected override void Awake()
    {
        base.Awake();

        _delay = new(_spawnDelay);

        if (_isSpawning)
            StartCoroutine(SpawnDelay());
    }

    protected override void OnGetObject(Enemy obj)
    {
        base.OnGetObject(obj);
        obj.ReturnedToPool += OnEnemyDied;
    }

    private void Spawn()
    {
        float y = Random.Range(_minY, _maxY);
        Enemy enemy = Pool.Get();
        enemy.transform.position = new Vector3(_spawnposition.position.x, y, 0);
        enemy.SetProjectileSpawner(_projectileSpawner);

        if (_isSpawning)
            StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay()
    {
        yield return _delay;
        Spawn();
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.ReturnedToPool -= OnEnemyDied;
        Pool.Release(enemy);
    }
}
