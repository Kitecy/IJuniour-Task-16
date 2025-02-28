using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpKeyCode;
    [SerializeField] private KeyCode _attackKeyCode;

    public event Action Jumped;
    public event Action Attacked;

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKeyCode))
            Jumped?.Invoke();

        if (Input.GetKeyDown(_attackKeyCode))
            Attacked?.Invoke();
    }
}
