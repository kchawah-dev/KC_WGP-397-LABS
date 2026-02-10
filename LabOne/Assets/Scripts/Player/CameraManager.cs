using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("References")]
    public GameObject menuPanel;
    public PlayerController playerController;

    private bool isMenuOpen = false;

    void Start()
    {
        CloseMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isMenuOpen)
                CloseMenu();
            else
                OpenMenu();
        }
    }

    void OpenMenu()
    {
        isMenuOpen = true;
        menuPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        playerController.enabled = false;
    }

    void CloseMenu()
    {
        isMenuOpen = false;
        menuPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerController.enabled = true;
    }
}