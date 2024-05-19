using ScriptableObjectArchitecture;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private IDamageable m_player => transform.GetComponent<IDamageable>();
    private IDamageable m_damageable;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_damageable = collision.gameObject.GetComponent<IDamageable>();

        m_player.Damage(1);
        if (m_damageable != null) m_damageable.Damage(1);
    }
}
