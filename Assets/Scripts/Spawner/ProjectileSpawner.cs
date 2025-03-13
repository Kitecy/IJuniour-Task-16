using UnityEngine;

public class ProjectileSpawner : Spawner<Projectile>
{
    [SerializeField] private Score _score;

    protected override void OnGetObject(Projectile obj)
    {
        base.OnGetObject(obj);
        obj.ReleasedToPool += OnProjectileDied;
    }

    protected override Projectile Create()
    {
        Projectile projectile = base.Create();
        projectile.SetScore(_score);
        return projectile;
    }

    private void OnProjectileDied(IPoolableObject projectile)
    {
        projectile.ReleasedToPool -= OnProjectileDied;
        ReleaseObject(projectile as Projectile);
    }
}