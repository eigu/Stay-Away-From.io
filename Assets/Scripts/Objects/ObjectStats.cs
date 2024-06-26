using ScriptableObjectArchitecture;
using UnityEngine;

public class ObjectStats : MonoBehaviour
{
    private ObjectStats m_objectStats;

    #region Health
    [SerializeField] protected private FloatVariable _defaultHealth;
    [field: SerializeField] public float CurrentHealth { get; set; }
    #endregion

    #region Speed
    [SerializeField] protected private FloatVariable _defaultSpeed;
    [field: SerializeField] public float CurrentSpeed{ get; set; }
    #endregion

    #region SpeedMultiplier
    [SerializeField] protected private FloatVariable _defaultSpeedMultiplier;
    [field: SerializeField] public float CurrentSpeedMultiplier { get; set; }
    #endregion

    #region Damage
    [SerializeField] protected private FloatVariable _defaultDamage;
    [field: SerializeField] public float CurrentDamage { get; set; }
    #endregion


    public void Initialize(GameObject obj)
    {
        m_objectStats = obj.GetComponent<ObjectStats>();

        m_objectStats.CurrentHealth = _defaultHealth.Value;
        m_objectStats.CurrentSpeed = _defaultSpeed.Value;
        m_objectStats.CurrentSpeedMultiplier = _defaultSpeedMultiplier.Value;
        m_objectStats.CurrentDamage = _defaultDamage.Value;
    }
}
