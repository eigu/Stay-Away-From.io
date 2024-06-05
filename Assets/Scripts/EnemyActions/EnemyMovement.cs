using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private ObjectStats _objectStats;

    [field: SerializeField] public Transform PlayerPosition { get; set; }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerPosition.position, _objectStats.CurrentSpeed * Time.deltaTime);
    }
}
