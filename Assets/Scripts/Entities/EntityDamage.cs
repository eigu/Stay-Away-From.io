using UnityEngine;

public interface IDamageable
{
    void Damage(int damageAmount);
}

public class EntityDamage : MonoBehaviour, IDamageable
{
    [SerializeField] private EntityStats _entityStats;

    public void Damage(int damageInput)
    {
        _entityStats.CurrentHealth -= damageInput;
    }
}
