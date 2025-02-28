using System.Collections;
using UnityEngine;

public class Enemy : Dieable
{
    [SerializeField] private AutoGun _autoGun;
    [SerializeField] private float _lifeTime;

    private WaitForSeconds _delay;

    private void Awake()
    {
        _delay = new(_lifeTime);
    }

    private void Start()
    {
        _autoGun.StartFire();
        StartCoroutine(WaitDeath());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            player.Die();
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }

    public void SetProjectileSpawner(ProjectileSpawner spawner)
    {
        _autoGun.SetProjectileSpawner(spawner);
    }

    private IEnumerator WaitDeath()
    {
        yield return _delay;
        Destroy(gameObject);
    }
}
