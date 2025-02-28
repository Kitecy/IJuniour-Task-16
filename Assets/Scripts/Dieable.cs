using System;
using UnityEngine;

public class Dieable : MonoBehaviour
{
    public event Action Died;

    public virtual void Die()
    {
        Died?.Invoke();
    }
}
