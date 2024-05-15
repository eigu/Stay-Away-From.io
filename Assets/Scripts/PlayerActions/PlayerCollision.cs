using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Hit {collision.gameObject.name}!");

        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null) damageable.Damage(1);
    }
}
