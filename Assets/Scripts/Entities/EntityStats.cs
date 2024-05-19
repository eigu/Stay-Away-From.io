using ScriptableObjectArchitecture;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    #region Health
    [SerializeField] protected private IntVariable _defaultHealth;
    [SerializeField] protected private IntVariable _currentHealth; 
    #endregion

    #region Speed
    [SerializeField] protected private FloatVariable _defaultSpeed;
    [SerializeField] protected private FloatVariable _currentSpeed;
    #endregion

    #region SpeedMultiplier
    [SerializeField] protected private FloatVariable _defaultSpeedMultiplier;
    [SerializeField] protected private FloatVariable _currentSpeedMultiplier;
    #endregion

    private void Start()
    {
        _currentHealth.Value = _defaultHealth.Value;
        _currentSpeed.Value = _defaultSpeed.Value;
        _currentSpeedMultiplier.Value = _defaultSpeedMultiplier.Value;
    }
}
