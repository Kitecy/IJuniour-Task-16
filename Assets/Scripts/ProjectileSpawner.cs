using UnityEngine;
using UnityEngine.Pool;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;

    [SerializeField] private int _defaultCapacity;
    [SerializeField] private int _maxCapacity;

    private ObjectPool<Projectile> _pool;

    private void Awake()
    {
        _pool = new(() => Instantiate(_projectile), actionOnGet: OnGetProjectile, actionOnRelease: OnReleaseProjectile, defaultCapacity: _defaultCapacity, maxSize: _maxCapacity);
    }

    public Projectile GetProjectile() =>
        _pool.Get();

    private void OnGetProjectile(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
        projectile.Died += OnProjectileDied;
    }

    private void OnReleaseProjectile(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }

    private void OnProjectileDied(Projectile projectile)
    {
        projectile.Died -= OnProjectileDied;
        _pool.Release(projectile);
    }
}
