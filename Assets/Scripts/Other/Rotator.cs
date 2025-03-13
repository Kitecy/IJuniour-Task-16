using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _min;
    [SerializeField] private float _max;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RotateSprite();
    }

    private void RotateSprite()
    {
        float angle;

        if (_rigidbody2D.linearVelocityY > 0)
            angle = _max;
        else
            angle = Mathf.LerpAngle(transform.eulerAngles.z, _min, _speed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
