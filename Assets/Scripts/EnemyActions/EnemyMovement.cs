using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private ObjectStats _objectStats;
    [SerializeField] private ObjectInstance _objectInstance;
    [SerializeField] private float minSpeed = 3f;
    [SerializeField] private float maxSpeed = 7f;
    [SerializeField] private float accelerationTime = 0.5f;
    [SerializeField] private float speedIncreaseAfterDodge = 0.5f;
    [SerializeField] private float dodgeDetectionDistance = 1.5f;

    private float currentSpeed;
    private float accelerationTimer;
    private Vector3 lastPlayerPosition;
    private bool playerDodged = false;

    private void Start()
    {
        currentSpeed = minSpeed;
        lastPlayerPosition = _objectInstance.PlayerPosition.position;
    }

    private void Update()
    {
        AggressivePursuit();
        CheckForDodge();
    }

    private void AggressivePursuit()
    {
        Vector3 playerPosition = _objectInstance.PlayerPosition.position;
        Vector3 directionToPlayer = (playerPosition - transform.position).normalized;

        // Accelerate over time
        accelerationTimer += Time.deltaTime;
        currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, accelerationTimer / accelerationTime);

        // Move towards the player
        transform.position += directionToPlayer * currentSpeed * Time.deltaTime;

        // Rotate to face movement direction
        if (directionToPlayer != Vector3.zero)
        {
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }

    private void CheckForDodge()
    {
        Vector3 playerPosition = _objectInstance.PlayerPosition.position;
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

        if (distanceToPlayer <= dodgeDetectionDistance && !playerDodged)
        {
            // Player is close, check if they've moved significantly
            if (Vector3.Distance(playerPosition, lastPlayerPosition) > dodgeDetectionDistance)
            {
                // Player has dodged
                IncreaseSpeedAfterDodge();
                playerDodged = true;
            }
        }
        else if (distanceToPlayer > dodgeDetectionDistance)
        {
            // Reset dodge detection when player is far enough
            playerDodged = false;
        }

        lastPlayerPosition = playerPosition;
    }

    private void IncreaseSpeedAfterDodge()
    {
        minSpeed += speedIncreaseAfterDodge;
        maxSpeed += speedIncreaseAfterDodge;
        currentSpeed += speedIncreaseAfterDodge;

        // Ensure speeds don't exceed any global maximum
        float globalMaxSpeed = 10f; // Adjust as needed
        minSpeed = Mathf.Min(minSpeed, globalMaxSpeed);
        maxSpeed = Mathf.Min(maxSpeed, globalMaxSpeed);
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

        Debug.Log($"Enemy speed increased. New range: {minSpeed} - {maxSpeed}");
    }   
}