using System;
using UnityEngine;
using UnityEngine.UI;

public class DeathPage : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    public event Action Restarted;

    private void Awake()
    {
        _restartButton.onClick.AddListener(Restart);
    }

    public void Activate()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Restarted?.Invoke();
    }
}
