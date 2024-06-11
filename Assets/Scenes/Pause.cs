using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel; // Reference to the pause panel
    public Button PauseBtn; // Reference to the pause button
    private bool isPaused = false;

    void Start()
    {
        // Add the listener for the Pause button
        PauseBtn.onClick.AddListener(TogglePause);
    }

    void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; // Pause the game
        Debug.Log("Game Paused");
        pausePanel.SetActive(true); // Show the pause panel
        PauseBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Resume"; // Update button text
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // Resume the game
        Debug.Log("Game Resumed");
        pausePanel.SetActive(false); // Hide the pause panel
        PauseBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Pause"; // Update button text
    }
}
