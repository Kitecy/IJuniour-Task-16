using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ProjectileSpawner _projectileSpawner;
    [SerializeField] private Transform _firePoint;

    public event Action Fired;

    public void Fire()
    {
        Projectile projectile = _projectileSpawner.GetProjectile();
        projectile.transform.position = _firePoint.position;
        projectile.ClearTrail();

        Fired?.Invoke();
    }

    public void SetProjectileSpawner(ProjectileSpawner spawner)
    {
        _projectileSpawner = spawner;
    }
}
