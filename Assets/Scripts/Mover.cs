using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        transform.Translate(_direction * _speed);
    }
}
