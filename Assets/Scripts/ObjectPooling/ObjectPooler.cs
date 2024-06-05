using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private ObjectInstance _objectPrefab;

    [SerializeField] private IntVariable _objectSpawnAmount;
    private int _objectSpawnIndex;

    [SerializeField] private FloatVariable _objectSpawnInterval;
    private float m_objectSpawnTimer;

    private IObjectPool<ObjectInstance> m_pool;
    [SerializeField] private int _poolDefaultCapacity;
    [SerializeField] private int _poolMaxSize;

    private ObjectInstance m_objectInstance;

    [SerializeField] private GameObjectEvent _onInitializeObject;

    private void Start()
    {
        m_pool = new ObjectPool<ObjectInstance>(
        CreateObject,
        OnGetFromPool,
        OnReleaseToPool,
        OnDestroyPooledObject,
        defaultCapacity: _poolDefaultCapacity,
        maxSize: _poolMaxSize);

        m_objectSpawnTimer = _objectSpawnInterval.Value;
    }

    private void Update()
    {
        m_objectSpawnTimer -= Time.deltaTime;

        if (m_objectSpawnTimer < 0)
        {
            Spawn();

            m_objectSpawnTimer = _objectSpawnInterval.Value;
        }
    }

    private ObjectInstance CreateObject()
    {
        ObjectInstance pooledObject = Instantiate(_objectPrefab);

        pooledObject.Pool = m_pool;

        return pooledObject;
    }

    private void OnGetFromPool(ObjectInstance pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(ObjectInstance pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    private void OnDestroyPooledObject(ObjectInstance pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }

    private void Spawn()
    {
        _objectSpawnIndex = 0;

        while (_objectSpawnIndex < _objectSpawnAmount.Value)
        {
            m_objectInstance = m_pool.Get();

            _onInitializeObject.Invoke(m_objectInstance.gameObject);

            _objectSpawnIndex++;
        }
    }
}
