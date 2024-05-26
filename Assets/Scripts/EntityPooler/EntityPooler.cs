using ScriptableObjectArchitecture;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.EventSystems.EventTrigger;

public class EntityPooler : MonoBehaviour
{
    [SerializeField] private GameObject _entityPrefab;
    [SerializeField] private IntVariable _entitySpawnAmount;
    [SerializeField] private FloatVariable _entitySpawnInterval;

    private IObjectPool<EntityDeath> m_pool;
    [SerializeField] private int _poolDefaultCapacity;

    [SerializeField] private Transform _playerPosition;
    private GameObject m_pooledEntity;

    private void Start()
    {
        m_pool = new ObjectPool<EntityDeath>(
        CreateObject,
        OnGetFromPool,
        OnReleaseToPool,
        defaultCapacity: _poolDefaultCapacity);

        //InvokeRepeating(nameof(Spawn), 1f, _entitySpawnInterval);
    }

    private EntityDeath CreateObject()
    {
        m_pooledEntity = Instantiate(_entityPrefab);

        EntityDeath entity = m_pooledEntity.GetComponent<EntityDeath>();

        entity.Pool = m_pool;

        EnemyMovement enemy = m_pooledEntity.GetComponent<EnemyMovement>();

        if (enemy != null) enemy.PlayerPosition = _playerPosition;

        return entity;
    }

    private void OnGetFromPool(EntityDeath pooledEntity)
    {
        pooledEntity.gameObject.SetActive(true);

        pooledEntity.gameObject.transform.position = Random.insideUnitSphere * 10;

        EntityStats entityStats = m_pooledEntity.GetComponent<EntityStats>();

        entityStats.CurrentHealth = 1;
    }

    private void OnReleaseToPool(EntityDeath pooledEntity)
    {
        pooledEntity.gameObject.SetActive(false);
    }

    [ContextMenu("Test")]
    private void Spawn()
    {
        m_pool.Get();
    }
}
