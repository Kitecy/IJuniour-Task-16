using UnityEngine;

public class PlayerRefresher : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private DeathPage _deathPage;

    private Quaternion _startQuaternion = Quaternion.Euler(0, 0, 0);

    private void OnEnable()
    {
        _deathPage.Restarted += Refresh;
    }

    private void OnDisable()
    {
        _deathPage.Restarted -= Refresh;
    }

    private void Refresh()
    {
        _player.position = _startPosition.position;
        _player.rotation = _startQuaternion;
    }
}
