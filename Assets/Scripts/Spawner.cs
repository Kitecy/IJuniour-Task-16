using System;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    [SerializeField] private int _defaultCapacity;
    [SerializeField] private int _maxCapacity;

    private ObjectPool<T> _pool;

    public event Action<T> Taken;
    public event Action<T> Released;

    protected virtual void Awake()
    {
        _pool = new(Create, actionOnGet: OnGetObject, actionOnRelease: OnReleaseObject, defaultCapacity: _defaultCapacity, maxSize: _maxCapacity);
    }

    public T GetObject() =>
        _pool.Get();

    public void ReleaseObject(T obj) =>
        _pool.Release(obj);

    protected virtual void OnGetObject(T obj)
    {
        obj.gameObject.SetActive(true);
        Taken?.Invoke(obj);
    }

    private void OnReleaseObject(T obj)
    {
        obj.gameObject.SetActive(false);
        Released?.Invoke(obj);
    }

    protected virtual T Create()
    {
        return Instantiate(_prefab);
    }
}