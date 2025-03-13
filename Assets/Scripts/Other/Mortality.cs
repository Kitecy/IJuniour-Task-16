using System;
using UnityEngine;

public class Mortality : MonoBehaviour
{
    public event Action Died;

    public virtual void Die()
    {
        Died?.Invoke();
    }
}
