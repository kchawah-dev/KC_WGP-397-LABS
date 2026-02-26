using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
        HandleJump();
    }

    void HandleMovement()
    {
        Vector3 move = new Vector3(input.Horizontal, 0, input.Vertical);
        Vector3 moveDirection = transform.TransformDirection(move);
        rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
}