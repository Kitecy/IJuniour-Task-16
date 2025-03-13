using UnityEngine;

public class GunView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireVFX;
    [SerializeField] private Gun _gun;

    private void OnEnable()
    {
        _gun.Fired += ShowParticles;
    }

    private void OnDisable()
    {
        _gun.Fired -= ShowParticles;
    }

    public void ShowParticles()
    {
        _fireVFX.Play();
    }
}
