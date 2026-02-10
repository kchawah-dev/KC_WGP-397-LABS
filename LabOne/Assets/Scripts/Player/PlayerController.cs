using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 200f;

    private InputReader input;

    public Transform cameraTransform;
    private float xRotation = 0f;

    void Start()
    {
        input = FindObjectOfType<InputReader>();

        if (input == null)
        {
            Debug.LogError("InputReader NOT FOUND in scene!");
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // movement
        Vector3 move = new Vector3(input.Horizontal, 0, input.Vertical);
        transform.Translate(move * speed * Time.deltaTime);

        // mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    public void SetCameraActive(bool active)
    {
        enabled = active;
    }
}