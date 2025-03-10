using System;
using UnityEngine;

public class DeathPage : MonoBehaviour
{
    public event Action Restarted;

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
