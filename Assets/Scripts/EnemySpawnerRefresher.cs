public class EnemySpawnerRefresher : SpawnerRefresher<Enemy>
{
    public override void Refresh()
    {
        for (int i = Active.Count - 1; i >= 0; i--)
            Active[i].Die();

        Active.Clear();
    }
}