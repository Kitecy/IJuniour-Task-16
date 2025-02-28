using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private TrailRenderer _trailRenderer;

    private Coroutine _coroutine;
    private WaitForSeconds _delay;

    public event Action<Projectile> Died;

    private void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();

        _delay = new(_lifeTime);
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(DeathWait());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Dieable dieable))
        {
            dieable.Die();
            Died?.Invoke(this);
        }
    }

    public void ClearTrail()
    {
        _trailRenderer.Clear();
    }

    private IEnumerator DeathWait()
    {
        yield return _delay;
        Died?.Invoke(this);
    }
}
