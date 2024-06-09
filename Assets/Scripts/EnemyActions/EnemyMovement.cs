using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private ObjectInstance _objectInstance;
    [SerializeField] private ObjectStats _objectStats;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            _objectInstance.PlayerPosition.position,
            _objectStats.CurrentSpeed * Time.deltaTime);
    }
}
