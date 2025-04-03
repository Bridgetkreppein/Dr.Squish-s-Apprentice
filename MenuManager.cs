using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject settingsCanvas;
    public GameObject gameOverCanvas;
    public GameObject winCanvas;
    public GameObject manualCanvas;
    public GameObject player;
    public PlayerController playerController;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P key pressed. isPaused: " + isPaused);
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }

        UpdateCursorVisibility();
    }

    void PauseGame()
    {
        Debug.Log("Pausing game");
        pauseCanvas.SetActive(true);
        
        if (playerController != null)
        {
            playerController.enabled = false;
            Debug.Log("PlayerController disabled");
        }

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resuming game");
        pauseCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        winCanvas.SetActive(false);
        manualCanvas.SetActive(false);
        
        if (playerController != null)
        {
            playerController.enabled = true;
            Debug.Log("PlayerController enabled");
        }
        else
        {
            Debug.LogWarning("PlayerController reference is missing");
        }
        
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.WakeUp();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Debug.Log("Rigidbody reactivated with velocity reset");
        }
        else
        {
            Debug.LogWarning("Rigidbody reference is missing on player");
        }

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ShowSettingsCanvas()
    {
        Debug.Log("Showing Settings Canvas");
        pauseCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void ShowGameOverCanvas()
    {
        Debug.Log("Showing Game Over Canvas");
        gameOverCanvas.SetActive(true);
    }

    public void ShowWinCanvas()
    {
        Debug.Log("Showing Win Canvas");
        winCanvas.SetActive(true);
    }

    public void ShowManualCanvas()
    {
        Debug.Log("Showing Manual Canvas");
        manualCanvas.SetActive(true);
    }

    public void ReturnFromManualToPause()
    {
        Debug.Log("Returning from Manual to Pause");
        manualCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
    }

    public void ReturnFromManualToMainMenu()
    {
        Debug.Log("Returning from Manual to Main Menu");
        manualCanvas.SetActive(false);
        LoadMainMenu();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void LoadMainMenu()
    {
        Debug.Log("Loading Main Menu");
        SceneManager.LoadScene(0);
    }

    public void RestartCurrentLevel()
    {
        Debug.Log("Restarting Current Level");
        Scene currentScene = (Scene)SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void LoadPlayerMovementLevel()
    {
        Debug.Log("Loading Player Movement Level");
        SceneManager.LoadScene(1);
    }

    private void UpdateCursorVisibility()
    {
        bool anyCanvasActive = pauseCanvas.activeSelf || settingsCanvas.activeSelf || gameOverCanvas.activeSelf || winCanvas.activeSelf || manualCanvas.activeSelf;
        Debug.Log("Updating Cursor Visibility: " + anyCanvasActive);
        
        if (anyCanvasActive)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
