using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyPooler : MonoBehaviour
{
    [SerializeField] private float m_deactivateDelay = 3f;

    private IObjectPool<GameObject> m_objectPool;
    public IObjectPool<GameObject> ObjectPool { set => m_objectPool = value; }

    [ContextMenu("Deactivate")]
    public void Deactivate()
    {
        StartCoroutine(DeactivateCoroutine(m_deactivateDelay));
    }

    private IEnumerator DeactivateCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        m_objectPool.Release(transform.gameObject);
    }
}
