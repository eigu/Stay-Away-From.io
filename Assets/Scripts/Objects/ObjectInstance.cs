using ScriptableObjectArchitecture;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectInstance : MonoBehaviour
{
    [SerializeField] private ObjectStats _objectStats;

    [SerializeField] private FloatVariable _objectDecayTimer;
    [SerializeField] private bool _isObjectDecayable;


    [field: SerializeField] public IObjectPool<ObjectInstance> Pool { get; set; }

    private void Update()
    {
        if (_objectStats.CurrentHealth <= 0) Pool.Release(this);
    }

    private void Decay()
    {
        if (_isObjectDecayable) StartCoroutine(DecayCoroutine(_objectDecayTimer));
    }

    private IEnumerator DecayCoroutine(float time)
    {
        yield return new WaitForSeconds(time);

        Pool.Release(this);
    }

    public void Initialize(GameObject objectInstance)
    {
        Decay();

        objectInstance.transform.position = Random.insideUnitSphere * 10;
    }
}
