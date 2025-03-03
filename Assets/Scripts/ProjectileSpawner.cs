public class ProjectileSpawner : Spawner<Projectile>
{
    protected override void OnGetObject(Projectile obj)
    {
        base.OnGetObject(obj);
        obj.Died += OnProjectileDied;
    }

    public Projectile GetProjectile() =>
        Pool.Get();

    private void OnProjectileDied(Projectile projectile)
    {
        projectile.Died -= OnProjectileDied;
        Pool.Release(projectile);
    }
}