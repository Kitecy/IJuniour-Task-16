using System;

public interface IPoolableObject
{
    public event Action<IPoolableObject> ReleasedToPool;

    void ReturnToPool();
}
