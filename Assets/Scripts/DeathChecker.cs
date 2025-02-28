using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathChecker : MonoBehaviour
{
    [SerializeField] private Dieable _player;

    private void OnEnable()
    {
        _player.Died += RestartLevel;
    }

    private void OnDisable()
    {
        _player.Died -= RestartLevel;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
