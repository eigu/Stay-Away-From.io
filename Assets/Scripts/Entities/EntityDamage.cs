using ScriptableObjectArchitecture;
using UnityEngine;

public interface IDamageable
{
    void Damage(int damageAmount);
}

public class EntityDamage : MonoBehaviour, IDamageable
{
    [SerializeField] protected private IntVariable _health;

    public void Damage(int damageInput)
    {
        _health.Value -= damageInput;
    }
}
