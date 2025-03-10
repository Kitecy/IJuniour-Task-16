using System;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    [SerializeField] private int _defaultCapacity;
    [SerializeField] private int _maxCapacity;

    protected ObjectPool<T> Pool;

    public event Action<T> Taken;
    public event Action<T> Released;

    protected virtual void Awake()
    {
        Pool = new(Create, actionOnGet: OnGetObject, actionOnRelease: OnReleaseObject, defaultCapacity: _defaultCapacity, maxSize: _maxCapacity);
    }

    public T GetObject() =>
        Pool.Get();

    public void ReleaseObject(T obj) =>
        Pool.Release(obj);

    protected virtual void OnGetObject(T obj)
    {
        obj.gameObject.SetActive(true);
        Taken?.Invoke(obj);
    }

    protected virtual void OnReleaseObject(T obj)
    {
        obj.gameObject.SetActive(false);
        Released?.Invoke(obj);
    }

    protected virtual T Create()
    {
        return Instantiate(_prefab);
    }
}