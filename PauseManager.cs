using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private PlayerController playerController; // Reference to disable movement

    private PlayerInput playerInput;
    private InputAction pauseAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        pauseAction = playerInput.actions["Pause"];
        pauseAction.performed += TogglePause;

        if (pauseCanvas != null)
        {
            pauseCanvas.SetActive(false);
            Debug.Log("PauseCanvas initially inactive");
        }
    }

    private void TogglePause(InputAction.CallbackContext context)
    {
        bool isPaused = !pauseCanvas.activeSelf;
        pauseCanvas.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;

        Debug.Log(isPaused ? "Game Paused" : "Game Unpaused");

        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (playerController != null)
            {
                playerController.enabled = false; // Disable movement
                Debug.Log("Player movement disabled");
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (playerController != null)
            {
                playerController.enabled = true; // Enable movement
                Debug.Log("Player movement enabled");
            }
        }
    }
}