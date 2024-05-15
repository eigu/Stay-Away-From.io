using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatVariable _speed;
    [SerializeField] private FloatVariable _speedMultiplier;

    private float m_currentSpeed;

    private Vector2 m_inputVector;
    private Vector3 m_movementVector;

    private Vector3 m_nextPosition;
    private float m_step;

    private void Update()
    {
        m_currentSpeed = _speed;
    }

    private void FixedUpdate()
    {
        m_step = m_currentSpeed * Time.deltaTime;

        m_nextPosition = transform.position + m_movementVector;

        transform.position = Vector3.Lerp(transform.position, m_nextPosition, m_step);
    }

    public void MoveInput(InputAction.CallbackContext input)
    {
        m_inputVector = input.ReadValue<Vector2>();

        if (m_inputVector == Vector2.zero)
        {
            m_movementVector = Vector3.zero;
            return;
        }

        m_movementVector = new Vector3(m_inputVector.x, m_inputVector.y, 0);
    }
}
