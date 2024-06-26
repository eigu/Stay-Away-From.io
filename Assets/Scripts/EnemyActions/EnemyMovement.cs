using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private ObjectStats _objectStats;

    [SerializeField] private ObjectInstance _objectInstance;

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            _objectInstance.PlayerPosition.position,
            _objectStats.CurrentSpeed * Time.deltaTime);
    }
}
