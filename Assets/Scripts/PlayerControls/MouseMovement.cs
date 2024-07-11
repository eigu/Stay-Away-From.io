using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private ObjectStats _objectStats;

    private Camera _mainCamera;
    private Vector3 _mousePosition;

    private Vector3 moveDirection;
    private Vector3 m_nextPosition;
    private float m_step;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        _mousePosition = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        m_step = _objectStats.CurrentSpeed * Time.deltaTime;

        moveDirection = (_mousePosition - transform.position).normalized;

        moveDirection.z = 0f;

        m_nextPosition = transform.position + moveDirection;

        transform.position = Vector3.MoveTowards(transform.position, m_nextPosition, m_step);
    }
}
