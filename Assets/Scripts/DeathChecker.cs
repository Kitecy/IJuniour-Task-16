using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    [SerializeField] private Dieable _player;
    [SerializeField] private DeathPage _deathPage;

    private void OnEnable()
    {
        _player.Died += ActivateDeathPage;
    }

    private void OnDisable()
    {
        _player.Died -= ActivateDeathPage;
    }

    private void ActivateDeathPage()
    {
        _deathPage.Activate();
    }
}
