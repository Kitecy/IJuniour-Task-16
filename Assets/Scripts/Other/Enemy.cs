using System;
using System.Collections;
using UnityEngine;

public class Enemy : Mortality, IPoolableObject
{
    [SerializeField] private AutoGun _autoGun;
    [SerializeField] private float _lifeTime;

    private WaitForSeconds _delay;

    public event Action<IPoolableObject> ReleasedToPool;

    private void Awake()
    {
        _delay = new(_lifeTime);
    }

    private void Start()
    {
        StartCoroutine(WaitDeath());
    }

    public void StartFire()
    {
        _autoGun.StartFire();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            player.Die();
    }

    public override void Die()
    {
        base.Die();
        ReturnToPool();
    }

    public void SetProjectileSpawner(ProjectileSpawner spawner)
    {
        _autoGun.SetProjectileSpawner(spawner);
    }

    private IEnumerator WaitDeath()
    {
        yield return _delay;
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        ReleasedToPool?.Invoke(this);
    }
}
