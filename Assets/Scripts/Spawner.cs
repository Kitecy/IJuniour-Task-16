using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    [SerializeField] private int _defaultCapacity;
    [SerializeField] private int _maxCapacity;

    protected ObjectPool<T> Pool;

    protected void Awake()
    {
        Pool = new(() => Instantiate(_prefab), actionOnGet: OnGetObject, actionOnRelease: OnReleaseObject, defaultCapacity: _defaultCapacity, maxSize: _maxCapacity);
    }

    public T GetObject() =>
        Pool.Get();

    protected virtual void OnGetObject(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    protected virtual void OnReleaseObject(T obj)
    {
        obj.gameObject.SetActive(false);
    }
}