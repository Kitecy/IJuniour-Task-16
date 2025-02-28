using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Gun))]
public class AutoGun : MonoBehaviour
{
    [SerializeField] private float _fireRate;

    private WaitForSeconds _delay;
    private bool _isFiring;

    private Gun _gun;

    private void Awake()
    {
        _gun = GetComponent<Gun>();
        _delay = new(_fireRate);
    }

    public void StartFire()
    {
        _isFiring = true;
        StartCoroutine(Fire());
    }

    public void StopFire()
    {
        _isFiring = false;
    }

    public void SetProjectileSpawner(ProjectileSpawner spawner)
    {
        _gun.SetProjectileSpawner(spawner);
    }

    private IEnumerator Fire()
    {
        while (_isFiring)
        {
            _gun.Fire();
            yield return _delay;
        }
    }
}
