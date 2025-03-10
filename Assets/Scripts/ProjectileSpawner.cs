using UnityEngine;

public class ProjectileSpawner : Spawner<Projectile>
{
    [SerializeField] private Score _score;

    protected override void OnGetObject(Projectile obj)
    {
        base.OnGetObject(obj);
        obj.Died += OnProjectileDied;
    }

    protected override Projectile Create()
    {
        Projectile projectile = base.Create();
        projectile.SetScore(_score);
        return projectile;
    }

    public Projectile GetProjectile() =>
        Pool.Get();

    private void OnProjectileDied(Projectile projectile)
    {
        projectile.Died -= OnProjectileDied;
        Pool.Release(projectile);
    }
}