using UnityEngine;
using ScriptableObjectArchitecture;

public class EntityStats : MonoBehaviour
{
    [SerializeField] protected private IntVariable _health;
    [SerializeField] protected private FloatVariable _speed;
    [SerializeField] protected private FloatVariable _speedMultiplier;
}
