using ScriptableObjectArchitecture;
using System.Collections;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    [SerializeField] private FloatVariable _combo;
    [SerializeField] private FloatVariable _comboIncrement;
    [SerializeField] private FloatVariable _comboDecayTimer;

    private Coroutine m_comboDecayCoroutine;

    private bool m_canGetCombo;

    private void Start()
    {
        ComboReset();
    }

    public void ComboGain()
    {
        if (m_comboDecayCoroutine != null) StopCoroutine(m_comboDecayCoroutine);

        if (!m_canGetCombo) return;

        _combo.Value += _comboIncrement;

        m_comboDecayCoroutine = StartCoroutine(DecayCoroutine(_comboDecayTimer));
    }

    private IEnumerator DecayCoroutine(float timer)
    {
        yield return new WaitForSeconds(timer);

        ComboReset();
    }

    public void ComboReset()
    {
        _combo.Value = 1;

        StartCoroutine(FlagReset());
    }

    private IEnumerator FlagReset()
    {
        m_canGetCombo = false;

        yield return new WaitForSeconds(0.5f);

        m_canGetCombo = true;
    }
}
