using ScriptableObjectArchitecture;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EntityDeath : MonoBehaviour
{
    [SerializeField] private EntityStats _entityStats;

    [SerializeField] private FloatVariable _entityDecayTimer;
    [SerializeField] private bool _isEntityDecayable;

    [field: SerializeField] public Coroutine EntityDecayCoroutine { get; set; }

    [field: SerializeField] public IObjectPool<EntityDeath> Pool { get; set; }

    private void Start()
    {
        //if (_isEntityDecayable) EntityDecayCoroutine = StartCoroutine(EntityDecay(_entityDecayTimer));
    }

    private void Update()
    {
        if (_entityStats.CurrentHealth <= 0) Pool.Release(this);

        //if (EntityDecayCoroutine != null)
        //{
        //    StopCoroutine(EntityDecayCoroutine);
        //    return;
        //}

    }

    private IEnumerator EntityDecay(float time)
    {
        yield return new WaitForSeconds(time);
        Pool.Release(this);
    }
}
