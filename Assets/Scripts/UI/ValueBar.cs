using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;

public class ValueBar : MonoBehaviour
{
    [SerializeField] private FloatVariable _maxValue;
    [SerializeField] private FloatVariable _currentValue;

    [SerializeField] private Image _valueBar;

    private void Update()
    {
        _valueBar.fillAmount = _currentValue / _maxValue.Value;
    }
}
