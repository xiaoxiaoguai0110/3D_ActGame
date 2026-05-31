using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private Transform target;
    [SerializeField] private float distance = 5f;
    [SerializeField] private float sensitivity = 5f;
    [SerializeField] private float minVerticalAngle = -30f;
    [SerializeField] private float maxVerticalAngle = 80f;

    private InputAction lookAction;
    private float currentHorizontalAngle;
    private float currentVerticalAngle;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        if (inputActions == null)
        {
            Debug.LogError("InputActionAsset 未赋值", this);
            return;
        }

        var playerMap = inputActions.FindActionMap("Player");
        if (playerMap == null)
        {
            Debug.LogError("未找到 'Player' ActionMap", this);
            return;
        }

        lookAction = playerMap.FindAction("Look");
        if (lookAction == null)
        {
            Debug.LogError("未找到 'Look' Action", this);
            return;
        }

        lookAction.Enable();
    }

    private void OnDisable()
    {
        lookAction?.Disable();
    }

    private void LateUpdate()
    {
        if (target == null || lookAction == null) return;

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            Cursor.lockState = CursorLockMode.None;

        if (Mouse.current.leftButton.wasPressedThisFrame && Cursor.lockState == CursorLockMode.None)
            Cursor.lockState = CursorLockMode.Locked;

        if (Cursor.lockState != CursorLockMode.Locked) return;

        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        currentHorizontalAngle += lookInput.x * sensitivity * Time.deltaTime;
        currentVerticalAngle -= lookInput.y * sensitivity * Time.deltaTime;
        currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, minVerticalAngle, maxVerticalAngle);

        Quaternion rotation = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0f);
        Vector3 position = target.position - rotation * Vector3.forward * distance;

        transform.position = position;
        transform.LookAt(target);
    }
}
