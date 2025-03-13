using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private DeathPage _deathPage;

    private int _value;

    public event Action<int> Changed;

    private void OnEnable()
    {
        _deathPage.Restarted += ThrowScore;
    }

    private void OnDisable()
    {
        _deathPage.Restarted -= ThrowScore;
    }

    public void AddValue()
    {
        _value++;
        Changed?.Invoke(_value);
    }

    private void ThrowScore()
    {
        _value = 0;
        Changed?.Invoke(_value);
    }
}
