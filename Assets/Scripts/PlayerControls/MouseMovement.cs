using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private ObjectStats _objectStats;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float deadzone = 0.1f;

    private Camera _mainCamera;
    private Vector2 _screenCenter;
    private Vector3 _movementDirection;

    private void Start()
    {
        _mainCamera = Camera.main;
        _screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
    }

    private void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 mouseOffset = (mousePosition - _screenCenter) / _screenCenter;

        // Apply deadzone
        mouseOffset = Vector2.ClampMagnitude(mouseOffset, 1f);
        if (mouseOffset.magnitude < deadzone)
        {
            mouseOffset = Vector2.zero;
        }
        else
        {
            mouseOffset = mouseOffset.normalized * ((mouseOffset.magnitude - deadzone) / (1 - deadzone));
        }

        _movementDirection = new Vector3(mouseOffset.x, mouseOffset.y, 0f) * mouseSensitivity;
    }

    private void FixedUpdate()
    {
        Vector3 movement = _movementDirection * _objectStats.CurrentSpeed * Time.fixedDeltaTime;
        transform.position += movement;
    }
}