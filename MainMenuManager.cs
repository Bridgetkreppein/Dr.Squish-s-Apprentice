using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject manualCanvas;
    public GameObject mainMenuCanvas;
    public GameObject settingsCanvas;
    public GameObject creditsCanvas;
    public GameObject controlsCanvas;

    public void ShowSettingsCanvas()
    {
        Debug.Log("Showing Settings Canvas");
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void HideSettingsCanvas()
    {
        Debug.Log("Hiding Settings Canvas");
        settingsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void ShowManualCanvas()
    {
        Debug.Log("Showing Manual Canvas");
        mainMenuCanvas.SetActive(false);
        manualCanvas.SetActive(true);
    }

    public void HideManualCanvas()
    {
        Debug.Log("Hiding Manual Canvas");
        manualCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void ShowCreditsCanvas()
    {
        Debug.Log("Showing Credits Canvas");
        mainMenuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void HideCreditsCanvas()
    {
        Debug.Log("Hiding Credits Canvas");
        creditsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void ShowControlsCanvas()
    {
        Debug.Log("Showing Controls Canvas");
        mainMenuCanvas.SetActive(false);
        controlsCanvas.SetActive(true);
    }

    public void HideControlsCanvas()
    {
        Debug.Log("Hiding Controls Canvas");
        controlsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void LoadPlayerMovementLevel()
    {
        string sceneName = "playermovement"; // Ensure this matches the exact scene name in Build Settings

        Debug.Log("Attempting to load scene: " + sceneName);

        try
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("Scene loaded successfully.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error loading scene: " + e.Message);
            Debug.LogError("Make sure the scene is added in Build Settings under File > Build Settings.");
        }
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
}
