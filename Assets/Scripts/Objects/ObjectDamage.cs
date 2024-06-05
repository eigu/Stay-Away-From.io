using UnityEngine;

public interface IDamageable
{
    void Damage(int damageAmount);
}

public class ObjectDamage : MonoBehaviour, IDamageable
{
    [SerializeField] private ObjectStats _objectStats;

    public void Damage(int damageInput)
    {
        _objectStats.CurrentHealth -= damageInput;
    }
}
