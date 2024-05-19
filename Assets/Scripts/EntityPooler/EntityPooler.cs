using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Pool;

public class EntityPooler : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private IntVariable _objectSpawnAmount;
    [SerializeField] private FloatVariable _objectSpawnInterval;

    private IObjectPool<GameObject> m_pool;

    [SerializeField] private int _poolDefaultCapacity;

    private void Start()
    {
        m_pool = new ObjectPool<GameObject>(
        CreateObject,
        OnGetFromPool,
        OnReleaseToPool,
        defaultCapacity: _poolDefaultCapacity);

        //InvokeRepeating(nameof(Spawn), 1f, _objectSpawnInterval);
    }

    private GameObject CreateObject()
    {
        return Instantiate(_objectPrefab);
    }

    private void OnGetFromPool(GameObject pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(GameObject pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    [ContextMenu("Pool Get")]
    private void Spawn()
    {
        m_pool.Get();
    }
}
