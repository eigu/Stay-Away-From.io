using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [field: SerializeField] public Transform PlayerPosition { get; set; }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerPosition.position, 1 * Time.deltaTime);
    }
}
