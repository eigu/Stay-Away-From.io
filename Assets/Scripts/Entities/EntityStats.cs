using ScriptableObjectArchitecture;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    #region Health
    [SerializeField] protected private IntVariable _defaultHealth;
    [field: SerializeField] public int CurrentHealth { get; set; }
    #endregion

    #region Speed
    [SerializeField] protected private FloatVariable _defaultSpeed;
    [field: SerializeField] public float CurrentSpeed{ get; set; }
    #endregion

    #region SpeedMultiplier
    [SerializeField] protected private FloatVariable _defaultSpeedMultiplier;
    [field: SerializeField] public float CurrentSpeedMultiplier { get; set; }
    #endregion

    private void Start()
    {
        CurrentHealth = _defaultHealth.Value;
        CurrentSpeed = _defaultSpeed.Value;
        CurrentSpeedMultiplier = _defaultSpeedMultiplier.Value;
    }
}
