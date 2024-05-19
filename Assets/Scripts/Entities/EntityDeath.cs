using ScriptableObjectArchitecture;
using UnityEngine;

public class EntityDeath : MonoBehaviour
{
    [SerializeField] private IntVariable _currentHealth;

    private void Update()
    {
        if (_currentHealth.Value <= 0) Destroy(gameObject);
    }
}
