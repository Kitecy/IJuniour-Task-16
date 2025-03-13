using System.Collections.Generic;
using UnityEngine;

public class SpawnerRefresher<T> : MonoBehaviour where T : MonoBehaviour, IPoolableObject
{
    [SerializeField] private Spawner<T> _spawner;
    [SerializeField] private DeathPage _deathPage;

    protected List<T> Active = new();

    private void OnEnable()
    {
        _spawner.Taken += OnTaken;
        _spawner.Released += OnReleased;
        _deathPage.Restarted += Refresh;
    }

    private void OnDisable()
    {
        _spawner.Taken -= OnTaken;
        _spawner.Released -= OnReleased;
        _deathPage.Restarted -= Refresh;
    }

    private void OnTaken(T obj)
    {
        Active.Add(obj);
    }

    private void OnReleased(T obj)
    {
        Active.Remove(obj);
    }

    public void Refresh()
    {
        for (int i = Active.Count - 1; i > 0; i--)
            Active[i].ReturnToPool();
    }
}
