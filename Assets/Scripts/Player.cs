using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private float moveSpeed = 1f; 
    [SerializeField] private float rotateSpeed = 5f;

    private InputAction moveAction;
    private Rigidbody rb;
    private Transform cameraTransform;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
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

        moveAction = playerMap.FindAction("Move");
        if (moveAction == null)
        {
            Debug.LogError("未找到 'Move' Action", this);
            return;
        }

        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction?.Disable();
    }

    private void FixedUpdate()
    {
        if (moveAction == null) return;

        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();

        Vector3 direction = cameraRight * moveInput.x + cameraForward * moveInput.y;

        animator.SetFloat("CurrentSpeed", direction.magnitude);

        if (direction.magnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotateSpeed * Time.fixedDeltaTime));
            rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
