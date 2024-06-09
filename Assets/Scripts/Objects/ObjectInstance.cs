using ScriptableObjectArchitecture;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectInstance : MonoBehaviour
{
    [SerializeField] private ObjectStats _objectStats;

    [SerializeField] private FloatVariable _objectDespawnTimer;
    [SerializeField] private bool _isObjectDespawnable;

    private bool m_isDespawned;

    [field: SerializeField] public IObjectPool<ObjectInstance> Pool { get; set; }

    [field: SerializeField] public Transform PlayerPosition { get; set; }
    [SerializeField] private FloatVariable _spawnRadius;

    private void Update()
    {
        if (m_isDespawned) return;

        if (_objectStats.CurrentHealth <= 0)
        {
            Pool.Release(this);

            m_isDespawned = true;
        }
    }

    public void Despawn(bool isDespawnable, ObjectInstance obj, float timer)
    {
        if (isDespawnable) StartCoroutine(DespawnCoroutine(obj, timer));
    }

    private IEnumerator DespawnCoroutine(ObjectInstance obj, float timer)
    {
        yield return new WaitForSeconds(timer);

        Pool.Release(obj);
    }

    public void Initialize(GameObject obj)
    {
        obj.gameObject.SetActive(true);

        ObjectInstance objectInstance = obj.GetComponent<ObjectInstance>();

        objectInstance.m_isDespawned = false;

        obj.transform.position = GetSpawnPoint(objectInstance.PlayerPosition, objectInstance._spawnRadius);

        objectInstance.Despawn(objectInstance._isObjectDespawnable, objectInstance, objectInstance._objectDespawnTimer);
    }

    private Vector3 GetSpawnPoint(Transform center, float radius)
    {
        float angle = Random.Range(0f, Mathf.PI * 2);

        float x = center.position.x + Mathf.Cos(angle) * radius;
        float y = center.position.y + Mathf.Sin(angle) * radius;

        return new Vector3(x, y, center.position.z);
    }
}
