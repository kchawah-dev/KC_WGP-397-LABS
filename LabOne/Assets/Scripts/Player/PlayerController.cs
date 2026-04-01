using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Mobile Input")]
    public Joystick joystick;

    [Header("Movement")]
    public float speed = 5f;
    public float jumpForce = 5f;

    [Header("Mouse Look")]
    public float mouseSensitivity = 200f;
    public Transform cameraTransform;

    [Header("Audio")]
    public AudioClip jumpSound;
    public AudioClip deathSound;

    private InputReader input;
    private Rigidbody rb;
    private AudioSource audioSource;

    private float xRotation = 0f;
    private bool isGrounded = true;

    void Start()
    {
        input = FindObjectOfType<InputReader>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        if (input == null)
            Debug.LogError("InputReader NOT FOUND in scene!");

        if (rb == null)
            Debug.LogError("Rigidbody NOT FOUND on Player!");

        if (audioSource == null)
            Debug.LogError("AudioSource NOT FOUND on Player!");

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // If joystick exists (mobile)
        if (joystick != null)
        {
            moveX = joystick.Horizontal;
            moveZ = joystick.Vertical;
        }
        else // fallback to keyboard
        {
            moveX = input.Horizontal;
            moveZ = input.Vertical;
        }
    
        Vector3 move = new Vector3(moveX, 0, moveZ);
        Vector3 moveDirection = transform.TransformDirection(move);

        rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
    }

    float touchX;
    float touchY;

    void HandleMouseLook()
    {
        float mouseX = 0f;
        float mouseY = 0f;

    #if UNITY_EDITOR
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    #else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                mouseX = touch.deltaPosition.x * mouseSensitivity * 0.01f * Time.deltaTime;
                mouseY = touch.deltaPosition.y * mouseSensitivity * 0.01f * Time.deltaTime;
            }
        }
    #endif

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
    
    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            if (audioSource != null && jumpSound != null)
                audioSource.PlayOneShot(jumpSound);

            isGrounded = false;
        }
    }

    // Simple death example (call this when needed)
    public void Die()
    {
        audioSource.PlayOneShot(deathSound);
        Debug.Log("Player died");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void SetCameraActive(bool active)
    {
        enabled = active;
    }

    public void HandleJump()
    {
        Jump();
    }


    public void HandleShoot()
    {
        Debug.Log("Shoot button pressed");
    }
}