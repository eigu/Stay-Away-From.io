using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

public class ValueCounter : MonoBehaviour
{
    [SerializeField] private FloatVariable _value;
    [SerializeField] private TextMeshProUGUI _valueText;

    [SerializeField] private string _prefix;
    [SerializeField] private string _suffix;

    private void Update()
    {
        _valueText.text = $"{_value.name.ToUpper()}: {_prefix}{_value.Value}{_suffix}";
    }
}
