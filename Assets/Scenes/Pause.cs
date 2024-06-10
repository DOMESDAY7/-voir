using UnityEngine;
using UnityEngine.XR;

public class Pause : MonoBehaviour
{
    // public Transform leftController;
    // public Transform rightController;
    public GameObject pausePanel; // Reference to the pause panel
    private bool isPaused = false;


    void Update()
    {
        
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; // Pause the game
        Debug.Log("Game Paused");
        pausePanel.SetActive(true); // Show the pause panel
        // Add any other code necessary to pause the game
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // Resume the game
        Debug.Log("Game Resumed");
        pausePanel.SetActive(false); // Hide the pause panel
        // Add any other code necessary to resume the game
    }
}
