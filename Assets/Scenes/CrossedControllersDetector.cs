using UnityEngine;
using UnityEngine.XR;

public class CrossedControllersDetector : MonoBehaviour
{
    public Transform leftController;
    public Transform rightController;
    public float crossDistanceThreshold = 0.1f; // Adjust this value as needed
    public GameObject pausePanel; // Reference to the pause panel
    private bool isPaused = false;


    void Update()
    {
        // Check the distance between the two controllers
        float distance = Vector3.Distance(leftController.position, rightController.position);

        if (distance <= crossDistanceThreshold && !isPaused)
        {
            PauseGame();
            return;
        }

         ResumeGame();
        
        
    }

    public void OnResume(){
        Debug.Log("resume");
        ResumeGame();
    }

    public void OnLeave(){
        Debug.Log("quit");
    }

    void PauseGame()
    {

       
        isPaused = true;
        Time.timeScale = 0; // Pause the game
        Debug.Log("Game Paused");
        pausePanel.SetActive(true); // Show the pause panel
        // Add any other code necessary to pause the game
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // Resume the game
        Debug.Log("Game Resumed");
        pausePanel.SetActive(false); // Hide the pause panel
        // Add any other code necessary to resume the game
    }
}
