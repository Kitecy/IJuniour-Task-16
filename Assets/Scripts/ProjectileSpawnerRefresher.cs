public class ProjectileSpawnerRefresher : SpawnerRefresher<Projectile>
{
    public override void Refresh()
    {
        for (int i = Active.Count - 1; i >= 0; i--)
            Active[i].Kill();

        Active.Clear();
    }
}
