using UnityEngine;

public class Player : Dieable
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Gun _gun;

    private void OnEnable()
    {
        _inputHandler.Jumped += _jumper.Jump;
        _inputHandler.Attacked += _gun.Fire;
    }

    private void OnDisable()
    {
        _inputHandler.Jumped -= _jumper.Jump;
        _inputHandler.Attacked -= _gun.Fire;
    }
}