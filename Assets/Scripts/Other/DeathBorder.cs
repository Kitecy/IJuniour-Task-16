using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DeathBorder : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            player.Die();
    }
}
