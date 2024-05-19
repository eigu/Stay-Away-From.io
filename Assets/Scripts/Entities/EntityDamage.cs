using ScriptableObjectArchitecture;
using UnityEngine;

public interface IDamageable
{
    void Damage(int damageAmount);
}

public class EntityDamage : MonoBehaviour, IDamageable
{
    [SerializeField] private IntVariable _currentHealth;

    public void Damage(int damageInput)
    {
        _currentHealth.Value -= damageInput;
    }
}
