using ScriptableObjectArchitecture;
using UnityEngine;

public class PlayerStats : ObjectStats
{
    [SerializeField] private FloatVariable PlayerCurrentHealth;

    private void Update()
    {
        PlayerCurrentHealth.Value = CurrentHealth;
    }

    private void Start()
    {
        Initialize(gameObject);
    }
}
