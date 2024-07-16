using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private ObjectStats _objectStats;
    [SerializeField] private ObjectInstance _objectInstance;
    [SerializeField] private float minSpeed = 2f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float accelerationTime = 1f;
    [SerializeField] private float wobbleAmount = 0.1f;
    [SerializeField] private float wobbleSpeed = 2f;

    private float currentSpeed;
    private float accelerationTimer;
    private Vector3 wobbleOffset;

    private void Update()
    {
        AggressivePursuit();
    }

    private void AggressivePursuit()
    {
        // Calculate direction to player
        Vector3 directionToPlayer = (_objectInstance.PlayerPosition.position - transform.position).normalized;

        // Accelerate over time
        accelerationTimer += Time.deltaTime;
        currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, accelerationTimer / accelerationTime);

        // Add a slight wobble to the movement
        wobbleOffset = new Vector3(
            Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount,
            Mathf.Cos(Time.time * wobbleSpeed) * wobbleAmount,
            0
        );

        // Move towards the player with wobble
        Vector3 movement = (directionToPlayer + wobbleOffset).normalized * currentSpeed * Time.deltaTime;
        transform.position += movement;

        // Optionally, rotate the enemy to face the movement direction
        if (movement != Vector3.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
}